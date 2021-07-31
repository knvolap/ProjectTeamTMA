using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class Floor
    {
        public int floorId { get; set; }
        public int buildingId { get; set; }
        public string floorName { get; set; }
        public DateTime createdTime { get; set; }
        public DateTime? updatedTime { get; set; }

        public Building Buildings { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
