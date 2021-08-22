using System;
using System.Collections.Generic;

namespace ProjectTeamTMA.Model
{
    public class Room
    {
       public Guid Id { get; set; }
       public Guid floorId { get; set; }
       public string roomName { get; set; }
       public string area { get; set; }
       public int NumberOfBeds { get; set; }
       public string status { get; set; }
       public DateTime createdTime { get; set; }
       public DateTime? updatedTime { get; set; }
       public Floor Floors { get; set; }
       public List<BookRoom> BookRooms { get; set; }
    }
}
