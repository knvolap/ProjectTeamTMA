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
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository roleRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;
        public RoleController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            roleRepository = new RoleRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> List()
        {
            var customers = await roleRepository.ListAsync();
            IEnumerable<Role> role = new List<Role>();
            _mapper.Map(customers, role);
            return Ok(role);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            Role role1 = new Role();
            _mapper.Map(role, role1);
            await roleRepository.AddAsync(role);
            return Ok(role.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            Role role1 = new Role();
            _mapper.Map(role, role1);
            await roleRepository.UpdateAsync(role);
            return Ok(role.Id);
        }

        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(int id)
        {
            Role role1 = await roleRepository.GetDetailAsync(id);
            if (role1 == null)
            {
                return NotFound();
            }
            await roleRepository.DeleteAsync(role1);
            return Ok();
        }


    }
}
