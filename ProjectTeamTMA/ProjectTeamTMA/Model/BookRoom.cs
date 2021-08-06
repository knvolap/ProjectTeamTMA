using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class BookRoom
    {
        public int Id { get; set; }
        public int personBookingId { get; set; }
        public int personalApprovedId { get; set; }
        public int roomId { get; set; }
        public string issue { get; set; }
        public DateTime startDay { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime? endTime { get; set; }
        public DateTime createdTime { get; set; }
        public DateTime? updatedTime { get; set; }
        public bool? status { get; set; }
        
        public User Users { get; set; }
        public Room Rooms { get; set; }
    }
}

