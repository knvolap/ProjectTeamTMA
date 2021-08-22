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
    public class FloorController : ControllerBase
    {
        private readonly FloorRepository floorRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;
        public FloorController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            floorRepository = new FloorRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Floor>>> List()
        {
            var floor1 = await floorRepository.ListAsync();
            IEnumerable<Floor> floor = new List<Floor>();
            _mapper.Map(floor1, floor);
            return Ok(floor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Floor floor)
        {
            Floor floor1 = new Floor();
            _mapper.Map(floor, floor1);
            await floorRepository.AddAsync(floor);
            return Ok(floor.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Floor floor)
        {
            Floor floor1 = new Floor();
            _mapper.Map(floor, floor1);
            await floorRepository.UpdateAsync(floor);
            return Ok(floor.Id);
        }

        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(Guid id)
        {
            Floor floor1 = await floorRepository.GetDetailAsync(id);
            if (floor1 == null)
            {
                return NotFound();
            }
            await floorRepository.DeleteAsync(floor1);
            return Ok();
        }
    }
}
