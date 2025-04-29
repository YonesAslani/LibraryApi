using LibraryDbManager.Context;
using LibraryDbManager.DbModels;
using LibraryServices.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Services
{
    public class AdminService : IAdminService
    {
        private readonly MyContext _Context;

        public AdminService(MyContext context)
        {
            _Context = context;
        }

        public async Task<Admin> GetAdminAsync(string UserName, string Password)
        {
            var result=await _Context.Admins.Where(a=>a.UserName==UserName && a.PassWord==Password).Include(i=>i.AdminType).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Admin> AddAdminAsync(Admin admin)
        {
            if (admin == null)
            {
                return null;
            }
            await _Context.Admins.AddAsync(admin);
            await _Context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> UpdateAdminAsync(string username, string password, Admin admin)
        {
            if(admin == null)
            {
                return null;
            }
            if(_Context.Admins.Any(a=>a.UserName == username && a.PassWord == password))
            {
                _Context.Admins.Update(admin);
                await _Context.SaveChangesAsync();
                return admin;
            }
            return null;
        }

        public async Task<Admin> DeleteAdminAsync(string usernmame, string password)
        {
            var admin=await _Context.Admins.FirstOrDefaultAsync(a=>a.UserName==usernmame && a.PassWord==password);
            if(admin == null)
            {
                return null;
            }
            _Context.Admins.Remove(admin);
            await _Context.SaveChangesAsync();
            return admin;
        }
    }
}
