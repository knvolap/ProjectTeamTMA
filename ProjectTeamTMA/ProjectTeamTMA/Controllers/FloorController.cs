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
    [Authorize(Roles = "Admin")]
    public class FloorController : ControllerBase
    {
        private readonly FloorRepository floorRepository;
        private MyDBContext myDbContext;
        public FloorController(MyDBContext _context)
        {
            this.myDbContext = _context;
            floorRepository = new FloorRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Floor>>> List()
        {
            var floor1 = await floorRepository.ListAsync();
            return Ok(floor1);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Floor floor)
        {
            int i = 0;
            var listFloor = myDbContext.Floors.ToList();
            foreach (var f in listFloor)
            {
                if (f.floorName == floor.floorName)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                await floorRepository.AddAsync(floor);
                return Ok(floor);
            }
            else return Ok("Floor name already exists");          
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Floor floor)
        {
            int i = 0;
            var floorEdit = myDbContext.Floors.Where(f => f.Id== id).FirstOrDefault();
            var listFloor = myDbContext.Floors.ToList();
            foreach (var f in listFloor)
            {
                if (f.floorName == floor.floorName)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                floorEdit.buildingId = floor.buildingId;
                floorEdit.floorName = floor.floorName;
                floorEdit.createdTime = floor.createdTime;
                floorEdit.updatedTime = floor.updatedTime;
                await floorRepository.UpdateAsync(floorEdit);
                return Ok(floorEdit);
            }
            else return Ok("Floor name already exists");
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
