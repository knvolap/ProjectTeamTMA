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
            await roomRepository.AddAsync(room);
            return Ok(room.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Room room)
        {        
            await roomRepository.UpdateAsync(room);
            return Ok(room.Id);
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(Room room)
        {
            await roomRepository.DeleteAsync(room);
            return Ok(room.Id);
        }
    }
}
