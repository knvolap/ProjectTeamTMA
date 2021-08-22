using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime startDay { get; set; }

        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan startTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan endTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime createdTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime? updatedTime { get; set; }
        public string status { get; set; }   //Approved and Disapproved and Processing

        public User Users { get; set; }
        public Room Rooms { get; set; }
    }
}

