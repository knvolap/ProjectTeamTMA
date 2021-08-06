using AutoMapper;
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
    public class RoomController : ControllerBase
    {
        private readonly RoomRepository roomRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;
        public RoomController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            roomRepository = new RoomRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> List()
        {
            var room1 = await roomRepository.ListAsync();
            IEnumerable<Room> room = new List<Room>();
            _mapper.Map(room1, room);
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            Room room1 = new Room();
            _mapper.Map(room, room1);
            await roomRepository.AddAsync(room);
            return Ok(room.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Room room)
        {
            Room room1 = new Room();
            _mapper.Map(room, room1);
            await roomRepository.UpdateAsync(room);
            return Ok(room.Id);
        }

        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(int id)
        {
            Room room1 = await roomRepository.GetDetailAsync(id);
            if (room1 == null)
            {
                return NotFound();
            }
            await roomRepository.DeleteAsync(room1);
            return Ok();
        }
    }
}
