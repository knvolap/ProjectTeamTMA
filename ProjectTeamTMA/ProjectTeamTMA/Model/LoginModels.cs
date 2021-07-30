using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class LoginModels
    {
        [Required(ErrorMessage = "User Name is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}
