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
        // status = accept and reject

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(BookRoom bookRoom)
        {                
            await bookRoomRepository.DeleteAsync(bookRoom);
            return Ok(bookRoom.Id);
        }

        //[HttpPut]
        //public async Task<IActionResult> BookRoomApproved2(BookRoom bookRoom)
        //{
        //    BookRoom bookRoom1 = new BookRoom();
        //    _mapper.Map(bookRoom, bookRoom1);
        //    await bookRoomRepository.UpdateAsync(bookRoom);
        //    return Ok(bookRoom.Id);
        //}
    }
}
