using LibraryDbManager.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.IServices
{
    public interface ICostumerServices
    {
        Task<Costumer> GetCostumerAsync(string username,string password);

        Task<Costumer> AddCostumerAsync(Costumer costumer);

        Task<Costumer> DeleteCostumerAsync(int id);

        Task<Costumer> UpdateCostumerAsync(Costumer costumer);

        Task<List<Costumer>> GetAllCotumersAsyn();
    }
}
