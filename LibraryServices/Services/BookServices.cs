using LibraryDbManager.Context;
using LibraryDbManager.DbModels;
using LibraryDbManager.ReturnModels;
using LibraryServices.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Services
{
    public class BookServices : IBookServices
    {
        private readonly MyContext _Context;

        public BookServices(MyContext context)
        {
            _Context = context;
        }

        public async Task<BookReturnModel> AddBookAsync(BookGetModel model)
        {
            if (model == null)
            {
                return null;
            }
            var book = new Book()
            {
                BookName = model.Name,
                BookCount = model.Count,
                BookWriter = model.Writer
            };

            book.Id= (await _Context.Books.AddAsync(book)).Property(p => p.Id).CurrentValue;
            

            var catids = await _Context.Category.Where(w => model.Categories.Contains(w.Id)).CountAsync();
            if (catids == model.Categories.Count())
            {
                var bookcatlist = model.Categories.Select(catid => new BookCategoryRelation()
                {
                    BookId = book.Id,
                    CategoryId = catid
                }).ToList();
                await _Context.bookCategoryRelations.AddRangeAsync(bookcatlist);
            }

            await _Context.SaveChangesAsync();
            return await GetBookAsync(book.Id);


        }

        public async Task<BookReturnModel> GetBookAsync(int id)
        {
            var result = await _Context.Books.Where(i => i.Id == id).Include(i => i.Categories).ThenInclude(t => t.Category)
                .Select(s => new BookReturnModel()
                {
                    Id = s.Id,
                    Name = s.BookName,
                    Count = s.BookCount,
                    Writer = s.BookWriter,
                    Categories =s.Categories.Select(i=>i.Category.Name).ToList()
                }).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            return result;

        }

        public async Task<BookReturnModel> DeleteBookAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var result = await _Context.Books.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            var book= await GetBookAsync(id);
            _Context.Books.Remove(result);
            await _Context.SaveChangesAsync();
            return book;
        }

        public async Task<BookReturnModel> UpdateBookAsync(int id,UpdateBookModel model)
        {
            if(model==null || id==0)
            {
                return null;
            }

            var book = await _Context.Books.FindAsync(id);
            if (book == null)
            {
                return null;
            }


            book.BookName = string.IsNullOrEmpty(model.Name) ? book.BookName : model.Name;
            book.BookWriter=string.IsNullOrEmpty(model.Writer) ? book.BookWriter : model.Writer;
            book.BookCount=(model.Count<=0 || model.Count==null)?book.BookCount:model.Count.Value;
            book.Id = id;
            _Context.Books.Update(book);

            if (model.Categories != null && model.Categories.Count > 0)
            {
                //var bookcat = _Context.bookCategoryRelations.Where(w => w.BookId == id && model.Categories.Contains(w.CategoryId) == false).ToList();

                //_Context.bookCategoryRelations.RemoveRange(bookcat);

                //var newcat = model.Categories.Where(w => book.Categories.Select(s => s.Id).Contains(w) == false).ToList();
                //_Context.bookCategoryRelations.AddRange(newcat.Select(s => new BookCategoryRelation()
                //{
                //    BookId = book.Id,
                //    CategoryId = s
                //}).ToList());

                var bookcats = await _Context.bookCategoryRelations.Where(w => w.BookId == id).ToListAsync();
                _Context.RemoveRange(bookcats);
                await _Context.bookCategoryRelations.AddRangeAsync(model.Categories.Select(s => new BookCategoryRelation()
                {
                    BookId = id,
                    CategoryId = s
                }).ToList());
            }

            await _Context.SaveChangesAsync();

            return await GetBookAsync(id);
        }

        public async Task<List<BookReturnModel>> GetAllBooksAsync()
        {
            var result = await _Context.Books.Include(i => i.Categories).ThenInclude(i => i.Category).Select(s => new BookReturnModel()
            {
                Id = s.Id,
                Name = s.BookName,
                Count = s.BookCount,
                Writer = s.BookWriter,
                Categories = s.Categories.Select(p => p.Category.Name).ToList()
            }).ToListAsync();

            return result;
        }
    }
}
