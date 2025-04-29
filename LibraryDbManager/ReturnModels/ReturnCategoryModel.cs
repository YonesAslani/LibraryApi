using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.ReturnModels
{
    public class ReturnCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookCategoryReturnModel> Books { get; set; }
    }

    public class BookCategoryReturnModel
    {
        public int Id { get; set; }
        public string BookName {  get; set; }
        public int BookCount { get; set; }
        public string BookWriter {  get; set; }
    }
}
