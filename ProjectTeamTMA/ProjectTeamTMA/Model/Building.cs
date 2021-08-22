using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class Building
    {        
        public Guid Id { get; set; }
        public string buildingName { get; set; }
        public DateTime createdTime { get; set; }
        public DateTime? updatedTime { get; set; }

        
        public List<Floor> Floors { get; set; }
    }
}
