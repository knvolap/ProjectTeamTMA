using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA
{
    public class BookRoomViewModel
    {
        public Guid Id { get; set; }
        public Guid personBookingId { get; set; }
        public Guid personalApprovedId { get; set; }
        public Guid roomId { get; set; }
        public string issue { get; set; }

      
        public string startDay { get; set; }

      
        public string endDate { get; set; }

      
        public string startTime { get; set; }

        public string endTime { get; set; }

        public string createdTime { get; set; }

        public string updatedTime { get; set; }
        public string status { get; set; } = "Processing";
    }
}

