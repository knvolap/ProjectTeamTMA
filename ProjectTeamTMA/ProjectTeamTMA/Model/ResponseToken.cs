using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class ResponseToken
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
