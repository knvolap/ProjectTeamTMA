using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTeamTMA.DBContexts;
using ProjectTeamTMA.Model;
using ProjectTeamTMA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class RoomController : ControllerBase
    {
        private readonly RoomRepository roomRepository;
        private MyDBContext myDbContext;
        public RoomController(MyDBContext _context)
        {
            this.myDbContext = _context;
            roomRepository = new RoomRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> List()
        {
            var room1 = await roomRepository.ListAsync();
            return Ok(room1);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            int i = 0;
            var listRoom = myDbContext.Rooms.ToList();
            foreach (var r in listRoom)
            {
                if (r.roomName == room.roomName)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                await roomRepository.AddAsync(room);
                return Ok(room);
            }
            else return Ok("Room name already exists");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Room room)
        {
            int i = 0;
            var roomEdit = myDbContext.Rooms.Where(r => r.Id == id).FirstOrDefault();
            var listRoom = myDbContext.Rooms.ToList();
            foreach (var r in listRoom)
            {
                if (r.roomName == room.roomName)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                roomEdit.floorId = room.floorId;
                roomEdit.roomName = room.roomName;
                roomEdit.createdTime = room.createdTime;
                roomEdit.updatedTime = room.updatedTime;
                await roomRepository.UpdateAsync(roomEdit);
                return Ok(roomEdit);
            }
            else return Ok("Room name already exists");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Room room = await roomRepository.GetDetailAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            await roomRepository.DeleteAsync(room);
            return Ok();
        }
    }
}
