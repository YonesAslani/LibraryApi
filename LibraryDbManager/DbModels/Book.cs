using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModels
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookWriter { get; set; }
        public int BookCount { get; set; }
        public List<BookCategoryRelation> Categories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
