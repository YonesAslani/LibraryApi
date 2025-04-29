using LibraryDbManager.DbModels;
using LibraryDbManager.ReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.IServices
{
    public interface IOrderServices
    {
        Task<string> AddOrderAsync(OrderGetModel order);

        Task<Order> GetOrderAsync(int CostumerId);

        Task<OrderDetail> GetOrderDetailAsync(int orderid);
    }
}
