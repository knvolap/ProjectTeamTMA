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
    public class BuildingController : ControllerBase
    {
        private readonly BuildingRepository buildingRepository;
        private readonly IMapper _mapper; 
        private MyDBContext myDbContext;
        public BuildingController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            buildingRepository = new BuildingRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> List()
        {
            var building1 = await buildingRepository.ListAsync();
            IEnumerable<Building> building = new List<Building>();
            _mapper.Map(building1, building);
            return Ok(building);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Building building)
        {
            Building building1 = new Building();
            _mapper.Map(building, building1);
            await buildingRepository.AddAsync(building);
            return Ok(building.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Building building)
        {
            Building building1 = new Building();
            _mapper.Map(building, building1);
            await buildingRepository.UpdateAsync(building);
            return Ok(building.Id);
        }

        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(int id)
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
