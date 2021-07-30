using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTeamTMA.DBContexts;
using ProjectTeamTMA.Interface;
using ProjectTeamTMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectTeamTMA.Repository;
using ProjectTeamTMA.Model;

namespace ProjectTeamTMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IIdentityService identityService;
        private readonly CustomerRepostitory customerRepostitory;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;

        public CustomerController(IIdentityService identityService, IMapper mapper, MyDBContext _context)
        {
            this.identityService = identityService;
            _mapper = mapper;
            customerRepostitory = new CustomerRepostitory(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> List2()
        {
            var customer1 = await customerRepostitory.ListAsync();
            IEnumerable<Customer> customers= new List<Customer>();
            _mapper.Map(customer1, customers);
            return Ok(customers);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] LoginModels loginModel)
        {
            ResponseToken authenResponse = identityService.Authentication(loginModel);

            return Ok(authenResponse);
        }

        // POST api/<UserController>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Customer customers)
        {
            Customer customer1 = new Customer();
            _mapper.Map(customers, customer1);
            await customerRepostitory.AddAsync(customers);
            return Ok(customers.IdCustomer);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer1 = await customerRepostitory.GetDetailAsync(id);
            if (customer1 == null)
            {
                return NotFound();
            }
            await customerRepostitory.DeleteAsync(customer1);
            return Ok();
        }
    }
}
