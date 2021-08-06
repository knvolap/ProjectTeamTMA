using System;
using System.Collections.Generic;

namespace ProjectTeamTMA.Model
{
    public class Room
    {
       public int Id { get; set; }
       public int floorId { get; set; }
       public string roomName { get; set; }
       public string area { get; set; }
       public int NumberOfBeds { get; set; }
       public bool? status { get; set; }
       public DateTime createdTime { get; set; }
       public DateTime? updatedTime { get; set; }

       public Floor Floors { get; set; }
       public BookRoom BookRooms { get; set; }
        
    }
}
