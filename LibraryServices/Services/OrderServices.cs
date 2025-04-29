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
    public class OrderServices : IOrderServices
    {
        private readonly MyContext _Context;

        public OrderServices(MyContext myContext)
        {
            _Context = myContext;
        }

        public async Task<string> AddOrderAsync(OrderGetModel ordermodel)
        {
            if(ordermodel.BookCount<=0 || ordermodel.Costumerid<=0 || ordermodel.BookId <= 0)
            {
                return "اطلاعات ورودی ناقص است";
            }
            else
            {
                var book = await _Context.Books.FirstOrDefaultAsync(i => i.Id == ordermodel.BookId);
                if (book.BookCount < ordermodel.BookCount)
                {
                    return "تعداد کتاب بیشتر از موجودی است";
                }
                if (book == null)
                {
                    return "کتاب وجود ندارد";
                }
                var costumer = await _Context.Costumers.FirstOrDefaultAsync(i => i.Id == ordermodel.Costumerid);
                if(costumer == null)
                {
                    return "کاربر وجود ندارد";
                }
                string result = string.Empty;
                var costumerorder = await _Context.Orders.FirstOrDefaultAsync(i => i.CostmerId == ordermodel.Costumerid && i.IsComplated == false);
                if (costumerorder != null)
                {
                    
                    var orderdetail = await _Context.OrderDetails.FirstOrDefaultAsync(i => i.BookId == ordermodel.BookId && i.OrderId == costumerorder.Id && i.IsReturned == false);
                    if (orderdetail != null)
                    {
                        
                        orderdetail.BookCount += ordermodel.BookCount;
                        book.BookCount-=ordermodel.BookCount;
                        
                        costumerorder.BookCount += ordermodel.BookCount;
                        _Context.OrderDetails.Update(orderdetail);

                    }
                    else
                    {
                        orderdetail = new OrderDetail()
                        {
                            BookId = ordermodel.BookId,
                            OrderId = costumerorder.Id,
                            IsReturned = false,
                            BookCount = 1,
                        };
                        await _Context.OrderDetails.AddAsync(orderdetail);
                        costumerorder.BookCount += ordermodel.BookCount;
                        book.BookCount -= ordermodel.BookCount;
                    }
                    _Context.Orders.Update(costumerorder);
                    _Context.Books.Update(book);
                    result = "سفارش به روز شد";
                }
                else
                {
                    var order = new Order()
                    {
                        BookCount = ordermodel.BookCount,
                        CostmerId = ordermodel.Costumerid,
                        IsComplated = false,
                        Time = DateTime.Now

                    };
                    order.Id = (await _Context.Orders.AddAsync(order)).Property(p => p.Id).CurrentValue;

                    var orderdetail = new OrderDetail()
                    {
                        BookId = ordermodel.BookId,
                        BookCount = ordermodel.BookCount,
                        IsReturned = false,
                        OrderId = order.Id
                    };
                    await _Context.OrderDetails.AddAsync(orderdetail);
                    book.BookCount -= ordermodel.BookCount;
                    result = "سفارش اضافه شد";
                }
                await _Context.SaveChangesAsync();
                return result;
            }
        }

        public async Task<Order> GetOrderAsync(int CostumerId)
        {
            var order = await _Context.Orders.FirstOrDefaultAsync(i => i.CostmerId == CostumerId);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<OrderDetail> GetOrderDetailAsync(int orderid)
        {
            var orderdetail=await _Context.OrderDetails.FirstOrDefaultAsync(i=>i.OrderId==orderid);
            if(orderdetail == null)
            {
                return null;
            }
            return orderdetail;
        }
    }
}
