using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Model
{
    public class BookRoom
    {
        public Guid Id { get; set; }
        public Guid personBookingId { get; set; }
        public Guid personalApprovedId { get; set; }
        public Guid roomId { get; set; }
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

