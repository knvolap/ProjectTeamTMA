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
        public async Task<ActionResult<IEnumerable<BookRoomViewModel>>> List()
        {
            var bookRoom1 = await bookRoomRepository.ListAsync2();
            IEnumerable<BookRoomViewModel> bookRoom = new List<BookRoomViewModel>();
            _mapper.Map(bookRoom1, bookRoom);
            return Ok(bookRoom);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Create(BookRoomViewModel model)
        {
            BookRoom bookRoom = new BookRoom()
            {            
                personBookingId = model.personBookingId,
                roomId = model.roomId,
                issue = model.issue,
                startDay = DateTime.Parse(model.startDay),
                endDate = DateTime.Parse(model.endDate),
                startTime = DateTime.Parse(model.startTime),
                endTime = DateTime.Parse(model.endDate),
                createdTime = DateTime.Parse(model.createdTime),
                updatedTime = DateTime.Parse(model.updatedTime)
            };
            await bookRoomRepository.AddAsync(bookRoom);
            return Ok(bookRoom.Id);
        }
        //check trùng date thì k cho đặt phòng

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> BookRoomApproved(BookRoomViewModel model)
        {
            BookRoom bookRoom = new BookRoom()
            {
                personalApprovedId = model.personalApprovedId,
                issue = model.issue,                    
                updatedTime = DateTime.Parse(model.updatedTime),
                status = model.status
            };
            await bookRoomRepository.UpdateAsync(bookRoom);
            return Ok(bookRoom.Id);
        }
        // status = Accept and Reject

        [HttpGet("bookRoomOfWeeb")]
        public async Task<ActionResult<IEnumerable<BookRoom>>> BookRoomOfWeek()
        {
            DateTime dt = DateTime.Now;
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            DateTime startDayOfWeeb = dt.AddDays(-diff + 1).Date;
            DateTime lastDayOfWeeb = startDayOfWeeb.AddDays(6);

            var model1 = from b in myDbContext.BookRooms
                         where ((DateTime.Compare(startDayOfWeeb, b.startDay) < 0) && (DateTime.Compare(lastDayOfWeeb, b.startDay) > 0))
                         select b;
            var model2 = new List<BookRoomViewModel>();
            foreach (var model in model1)
            {
                BookRoomViewModel book = new BookRoomViewModel()
                {
                    Id = model.Id,
                    personBookingId = model.personBookingId,
                    personalApprovedId = model.personalApprovedId,
                    roomId = model.roomId,
                    issue = model.issue,
                    startDay = model.startDay.ToString(),
                    endDate = model.endDate.ToString(),
                    startTime = model.startTime.ToString(),
                    endTime = model.endTime.ToString(),
                    createdTime = model.createdTime.ToString(),
                    updatedTime = model.updatedTime.ToString()
                };
                model2.Add(book);
            }
            return Ok(model2);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(BookRoom bookRoom)
        {                
            await bookRoomRepository.DeleteAsync(bookRoom);
            return Ok(bookRoom.Id);
        }

      
    }
}
