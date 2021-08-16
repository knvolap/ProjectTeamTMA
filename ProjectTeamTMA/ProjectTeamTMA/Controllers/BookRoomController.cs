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
    public class BookRoomController : ControllerBase
    {
        private readonly BookRoomRepository bookRoomRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;
        public BookRoomController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            bookRoomRepository = new BookRoomRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookRoom>>> List()
        {
            var bookRoom1 = await bookRoomRepository.ListAsync();
            IEnumerable<BookRoom> bookRoom = new List<BookRoom>();
            _mapper.Map(bookRoom1, bookRoom);
            return Ok(bookRoom);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Create(BookRoom bookRoom)
        {
            BookRoom bookRoom1 = new BookRoom();
            _mapper.Map(bookRoom, bookRoom1);
            await bookRoomRepository.AddAsync(bookRoom);
            return Ok(bookRoom.Id);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPut]
        //public async Task<IActionResult> Create(BookRoom bookRoom)
        //{
        //    BookRoom bookRoom1 = new BookRoom();
        //    _mapper.Map(bookRoom, bookRoom1);
        //    await bookRoomRepository.AddAsync(bookRoom);
        //    return Ok(bookRoom.Id);
        
    }
}
