using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.ReturnModels
{
    public class UpdateBookModel
    {
        public string? Name { get; set; }
        public int? Count { get; set; }
        public string? Writer { get; set; }
        public List<int>? Categories { get; set; }
    }
}
