using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDbManager.Context;
using LibraryDbManager.DbModels;
using LibraryDbManager.ReturnModels;
using LibraryServices.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LibraryServices.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly MyContext _Context;

        public CategoryServices(MyContext context)
        {
            _Context = context;
        }

        public async Task<Category> AddCategoryAsync(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return null;
            }
            var cat = (await _Context.Category.AddAsync(new Category { Name=Name})).Entity;
            await _Context.SaveChangesAsync();
            return cat;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var result = await _Context.Category.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            _Context.Remove(result);
            await _Context.SaveChangesAsync();
            return result;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var result = await _Context.Category.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> IsCategoryExist(int id)
        {
            if (await _Context.Category.FindAsync(id)==null)
            {
                return false;
            }
            return true;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            if (category == null)
            {
                return null;
            }
            if(await _Context.Category.AnyAsync(i=>i.Id == category.Id))
            {
                _Context.Category.Update(category);
                await _Context.SaveChangesAsync();
                return category;
            }
            return null;
            
        }

        public async Task<List<ReturnCategoryModel>> GetAllCategoriesAsync()
        {
            return await _Context.Category.Include(i => i.Books).ThenInclude(i => i.Book).Select(s => new ReturnCategoryModel()
            {
                Id = s.Id,
                Name = s.Name,
                Books = s.Books.Select(p => new BookCategoryReturnModel()
                {
                    Id = p.Book.Id,
                    BookName = p.Book.BookName,
                    BookCount = p.Book.BookCount,
                    BookWriter = p.Book.BookWriter
                }).ToList()
            }).ToListAsync();
        }
    }
}
