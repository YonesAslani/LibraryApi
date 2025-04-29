using LibraryDbManager.DbModels;
using LibraryDbManager.ReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.IServices
{
    public interface ICategoryServices
    {
        Task<Category> GetCategoryAsync(int id);

        Task<Category> AddCategoryAsync(string Name);

        Task<Category> DeleteCategoryAsync(int id);

        Task<Category> UpdateCategoryAsync(Category category);

        Task<bool> IsCategoryExist(int id);

        Task<List<ReturnCategoryModel>> GetAllCategoriesAsync();
    }
}
