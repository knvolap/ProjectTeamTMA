using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTeamTMA.DBContexts;
using ProjectTeamTMA.Interface;
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
    public class UserController : ControllerBase
    {
        private readonly IIdentityService identityService;
        private readonly UserRepostitory userRepostitory;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;

        public UserController(IIdentityService identityService, IMapper mapper, MyDBContext _context)
        {
            this.identityService = identityService;
            _mapper = mapper;
            userRepostitory = new UserRepostitory(_context);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] LoginModels loginModel)
        {
            ResponseToken authenResponse = identityService.Authentication(loginModel);

            return Ok(authenResponse);
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> List2()
        {
            var user1 = await userRepostitory.ListAsync();
            IEnumerable<User> users = new List<User>();
            _mapper.Map(user1, users);
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            User user1 = new User();
            _mapper.Map(user, user1);
            await userRepostitory.AddAsync(user);
            return Ok(user.userId);
        }
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            User user1 = new User();
            _mapper.Map(user, user1);
            await userRepostitory.UpdateAsync(user);
            return Ok(user.userId);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(int id)
        {
            User user1 = await userRepostitory.GetDetailAsync(id);
            if (user1 == null)
            {
                return NotFound();
            }
            await userRepostitory.DeleteAsync(user1);
            return Ok();
        }

    }
}
