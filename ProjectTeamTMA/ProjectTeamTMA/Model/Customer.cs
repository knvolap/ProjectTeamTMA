using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class Customer
    {
            public int IdCustomer { get; set; }
            public string Role { get; set; }
            public string NameCustomer { get; set; }
            public int Phone { get; set; }    
            public string Address { get; set; }
            public string Account { get; set; }
            public string Password { get; set; }
            public bool? Status { get; set; }


      
            //public List<BookRoom> BookRooms { get; set; }
        }
    }

