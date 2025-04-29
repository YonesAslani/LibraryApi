using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModels
{
    public class Order
    {
        public int Id { get; set; }
        public int CostmerId {  get; set; }
        public int BookCount {  get; set; }
        public bool IsComplated {  get; set; }
        public DateTime Time { get; set; }
        public Costumer Costumer { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
}
