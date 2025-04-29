using LibraryDbManager.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.ReturnModels
{
    public class AmanatiReturnModel
    {
        public int CostumerId { get; set; }
        public int BookCount { get; set; }
        public string Time { get; set; }
        public BookReturnModel Book { get; set; }
    }
}
