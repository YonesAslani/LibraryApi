using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModels
{
    public class AdminType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Admin Admin { get; set; }
    }
}
