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

            BookRoom book = new BookRoom()
            {
                personBookingId = bookRoom.personBookingId,
                roomId = bookRoom.roomId,
                issue = bookRoom.issue,
                startDay = DateTime.Now.Date,
                endDate = DateTime.Now.Date,
                startTime = DateTime.Parse(DateTime.Now.TimeOfDay.ToString()),
                endTime = DateTime.Parse(DateTime.Now.TimeOfDay.ToString()),
                createdTime = DateTime.Now.Date,
            };
            await bookRoomRepository.AddAsync(book);
            return Ok(bookRoom.Id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> BookRoomApproved(BookRoom bookRoom)
        {
            BookRoom bookRoom1 = await bookRoomRepository.GetDetailAsync(bookRoom.Id);
            bookRoom1.Id = bookRoom.Id;
            bookRoom1.personalApprovedId = bookRoom.personalApprovedId;
            bookRoom1.issue = bookRoom.issue;
            bookRoom1.updatedTime = DateTime.Now.Date;
            bookRoom1.status = bookRoom.status;
            await bookRoomRepository.AddAsync(bookRoom1);
            return Ok();
        }
        // status = accept and reject
    }
}
