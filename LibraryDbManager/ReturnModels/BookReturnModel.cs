using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.ReturnModels
{
    public class BookReturnModel
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public int Count {  get; set; }
        public string Writer {  get; set; }
        public List<string> Categories { get; set; }
    }
}
