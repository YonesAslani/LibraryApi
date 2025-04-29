using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModels
{
    public class Admin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public int AdminTypeId { get; set; }
        public AdminType? AdminType { get; set; }
    }
}
