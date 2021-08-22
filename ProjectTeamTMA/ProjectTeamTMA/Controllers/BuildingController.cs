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
    public class BuildingController : ControllerBase
    {
        private readonly BuildingRepository buildingRepository;
        private readonly MyDBContext myDbContext;
        public BuildingController(MyDBContext _context)
        {
            buildingRepository = new BuildingRepository(_context);
            this.myDbContext = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> List()
        {
            var building1 = await buildingRepository.ListAsync();
            return Ok(building1);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Building building)
        {
            int i = 0;
            var listBuilding = myDbContext.Buildings.ToList();
            foreach(var b in listBuilding)
            {
                if (b.buildingName == building.buildingName)
                {
                    i++;
                }
            }
            if (i==0)
            {
                await buildingRepository.AddAsync(building);
                return Ok(building);
            }
            else return Ok("Building name already exists");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Building building)
        {
            int i = 0;
            var listBuilding = myDbContext.Buildings.ToList();
            foreach (var b in listBuilding)
            {
                if (b.buildingName == building.buildingName)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                await buildingRepository.UpdateAsync(building);
                return Ok(building);
            }
            else return Ok("Building name already exists");
        }

        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(Guid id)
        {
            Building building1 = await buildingRepository.GetDetailAsync(id);
            if (building1 == null)
            {
                return NotFound();
            }
            await buildingRepository.DeleteAsync(building1);
            return Ok();
        }
    }
}
