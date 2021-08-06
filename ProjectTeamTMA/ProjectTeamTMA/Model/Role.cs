using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class Role
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public DateTime createdTime { get; set; }
        public DateTime? updatedTime { get; set; }

        //public List<User> Users { get; set; }
    }
}
