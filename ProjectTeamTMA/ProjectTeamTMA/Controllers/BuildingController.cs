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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] Building building)
        {
            int i = 0;
            var buildingEdit = myDbContext.Buildings.Where(b => b.Id == id).FirstOrDefault();
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
                buildingEdit.buildingName = building.buildingName;
                buildingEdit.createdTime = building.createdTime;
                buildingEdit.updatedTime = building.updatedTime;
                await buildingRepository.UpdateAsync(buildingEdit);
                return Ok(buildingEdit);
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
