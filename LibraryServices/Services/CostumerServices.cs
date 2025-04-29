using LibraryDbManager.Context;
using LibraryDbManager.DbModels;
using LibraryServices.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Services
{
    public class CostumerServices:ICostumerServices
    {
        private readonly MyContext _Context;

        public CostumerServices(MyContext context)
        {
            _Context = context;
        }

        public async Task<Costumer> AddCostumerAsync(Costumer costumer)
        {
            if (costumer == null)
            {
                return null;
            }
            if((await _Context.Costumers.AnyAsync(a=>a.NationalCode==costumer.NationalCode || a.PhoneNumber == costumer.PhoneNumber)))
            {
                return null;
            }
            costumer.Id=(await _Context.Costumers.AddAsync(costumer)).Property(p=>p.Id).CurrentValue;
            await _Context.SaveChangesAsync();
            return await GetCostumerAsync(costumer.UserName,costumer.PassWord);
        }

        public async Task<Costumer> GetCostumerAsync(string username,string password)
        {
            if (!username.IsNullOrEmpty() || !password.IsNullOrEmpty())
            {
                var result = await _Context.Costumers.FirstOrDefaultAsync(i=>i.UserName==username && i.PassWord==password);
                if(result == null)
                {
                    return null;
                }
                return result;
            }
            return null;
        }

        public async Task<Costumer> DeleteCostumerAsync(int id)
        {
            if (id > 0)
            {
                var result= await _Context.Costumers.FindAsync(id);
                if (result == null)
                {
                    return null;
                }
                _Context.Costumers.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Costumer> UpdateCostumerAsync(Costumer costumer)
        {
            if(costumer == null)
            {
                return null;
            }
            _Context.Costumers.Update(costumer);
            await _Context.SaveChangesAsync();
            return costumer;
        }

        public async Task<List<Costumer>> GetAllCotumersAsyn()
        {
            var result = await _Context.Costumers.ToListAsync();
            return result;
        }
    }
}
