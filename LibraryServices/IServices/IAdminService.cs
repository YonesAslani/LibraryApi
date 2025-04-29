using LibraryDbManager.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryServices.IServices
{
    public interface IAdminService
    {
        Task<Admin> GetAdminAsync(string UserName, string Password);

        Task<Admin> AddAdminAsync(Admin admin);

        Task<Admin> UpdateAdminAsync(string username,string password,Admin admin);
        Task<Admin> DeleteAdminAsync(string username,string password);
    }
}
