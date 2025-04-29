using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModels
{
    public class Costumer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public List<Order> Orders { get; set; }

    }
}
