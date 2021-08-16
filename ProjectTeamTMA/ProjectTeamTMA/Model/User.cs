using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class User
    {
            public Guid Id { get; set; }
            public Guid roleId { get; set; }
            public string name { get; set; }
            public int phone { get; set; }    
            public string address { get; set; }
            public string userName { get; set; }
            public string passWord { get; set; }
            public bool? status { get; set; }
            public DateTime createdTime { get; set; }
            public DateTime? updatedTime { get; set; }

        public Role Roles { get; set; }
        public List<BookRoom> BookRooms { get; set; }
    }
}

