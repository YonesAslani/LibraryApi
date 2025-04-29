using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModels
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int BookId {  get; set; }
        public int OrderId {  get; set; }
        public int BookCount {  get; set; }
        public bool IsReturned {  get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
