using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationV.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string CityCode { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
    }
}
