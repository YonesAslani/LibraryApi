using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using LibraryDbManager.DbModels;
using LibraryDbManager.ReturnModels;

namespace LibraryServices.IServices
{
    public interface IBookServices
    {
        Task<BookReturnModel> GetBookAsync(int id);

        Task<BookReturnModel> AddBookAsync(BookGetModel model);

        Task<BookReturnModel> DeleteBookAsync(int id);

        Task<BookReturnModel> UpdateBookAsync(int id, UpdateBookModel model);

        Task<List<BookReturnModel>> GetAllBooksAsync();
    }
}
