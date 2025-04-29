using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.ReturnModels
{
    public class OrderGetModel
    {
        public int Costumerid {  get; set; }
        public int BookId {  get; set; }
        public int BookCount {  get; set; }
    }
}
