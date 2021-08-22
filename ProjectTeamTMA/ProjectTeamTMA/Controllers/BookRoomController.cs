using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTeamTMA.DBContexts;
using ProjectTeamTMA.Model;
using ProjectTeamTMA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            this.myDbContext = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookRoomViewModel>>> List2()
        {
            var bookroom1 = await bookRoomRepository.ListAsync2();
            IEnumerable<BookRoomViewModel> bookroom = new List<BookRoomViewModel>();
            _mapper.Map(bookroom1, bookroom);
            return Ok(bookroom);
        }
        [HttpGet("findall")]
        public async Task<ActionResult<IEnumerable<BookRoom>>> List1()
        {
            var model1 = await bookRoomRepository.ListAsync();
            var model2 =  new List<BookRoomViewModel>(); 
            foreach (var model in model1)
            {
                BookRoomViewModel book = new BookRoomViewModel()
                {
                    Id=model.Id,
                    personBookingId = model.personBookingId,
                    personalApprovedId=model.personalApprovedId,
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
                startTime = TimeSpan.Parse(model.startTime),
                endTime = TimeSpan.Parse(model.endTime),
                createdTime = DateTime.Parse(model.createdTime),
                updatedTime = DateTime.Parse(model.updatedTime)
            };
            await bookRoomRepository.AddAsync(bookRoom);
            return Ok(bookRoom);
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


        [Authorize(Roles = "User,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookRoomViewModel bookRoom)
        {
            string massge = "";
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userRole = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;
            var boookRoomEdit = myDbContext.BookRooms.Where(b => b.Id == id).FirstOrDefault();
            string st = bookRoom.status;
            var check = from r in myDbContext.BookRooms
                        where ((r.roomId == bookRoom.roomId)
                        && (r.Id != id)
                        && (((DateTime.Compare(r.startDay,DateTime.Parse(bookRoom.startDay)) >= 0) && (DateTime.Compare(r.startDay, DateTime.Parse(bookRoom.endDate)) <= 0)) || ((DateTime.Compare(DateTime.Parse(bookRoom.startDay), r.startDay) >= 0) && (DateTime.Compare(DateTime.Parse(bookRoom.startDay), (DateTime)r.endDate) <= 0)))
                        && (((TimeSpan.Compare(r.startTime, TimeSpan.Parse(bookRoom.startTime)) >= 0) && (TimeSpan.Compare(r.startTime, TimeSpan.Parse(bookRoom.endTime)) <= 0)) || ((TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), r.startTime) >= 0) && (TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), r.endTime) <= 0))))
                        select r;
            if ((DateTime.Compare(DateTime.Parse(bookRoom.startDay), DateTime.Parse(bookRoom.endDate)) > 0) || (TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), TimeSpan.Parse(bookRoom.endTime)) > 0) || (DateTime.Compare(DateTime.Parse(bookRoom.startDay), DateTime.Now) < 0))
            {
                massge = "Invalid date and time ";
            }
            else
            {
                if (check.Count() > 0)
                {
                    massge = "Duplicate date and time";
                }
                else
                {
                    if ((userRole == "User" && st == "Processing") || (userRole == "Admin"))
                    {
                        boookRoomEdit.personBookingId = bookRoom.personBookingId;
                        boookRoomEdit.personalApprovedId = bookRoom.personalApprovedId;
                        boookRoomEdit.roomId = bookRoom.roomId;
                        boookRoomEdit.issue = bookRoom.issue;
                        boookRoomEdit.startDay = DateTime.Parse(bookRoom.startDay);
                        boookRoomEdit.endDate = DateTime.Parse(bookRoom.endDate);
                        boookRoomEdit.startTime =TimeSpan.Parse(bookRoom.startTime);
                        boookRoomEdit.endTime = TimeSpan.Parse(bookRoom.endTime);
                        boookRoomEdit.createdTime = DateTime.Parse(bookRoom.createdTime);
                        boookRoomEdit.updatedTime = DateTime.Parse(bookRoom.updatedTime);
                        boookRoomEdit.status = bookRoom.status;
                        await bookRoomRepository.UpdateAsync(boookRoomEdit);
                        massge = "Update successful";
                    }
                    else
                    {
                        massge = "Update failed";
                    }
                }
            }
            return Ok(massge);
        }







        //[Authorize(Roles = "User,Admin")]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id,[FromBody] BookRoom bookRoom)
        //{
        //    string massge = "";
        //    var claimsIdentity = this.User.Identity as ClaimsIdentity;
        //    var userRole = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;
        //    var boookRoomEdit = myDbContext.BookRooms.Where(b => b.Id == id).FirstOrDefault();
        //    string st = bookRoom.status;
        //    var check = from r in myDbContext.BookRooms
        //                where ((r.roomId==bookRoom.roomId) 
        //                && (r.Id != id)
        //                && (((DateTime.Compare(r.startDay, bookRoom.startDay) >= 0) && (DateTime.Compare(r.startDay, (DateTime)bookRoom.endDate) <= 0)) || ((DateTime.Compare(bookRoom.startDay,r.startDay)>=0) && (DateTime.Compare(bookRoom.startDay, (DateTime)r.endDate)<=0))) 
        //                && (((TimeSpan.Compare(r.startTime, bookRoom.startTime) >= 0) && (TimeSpan.Compare(r.startTime, bookRoom.endTime) <= 0)) || ((TimeSpan.Compare(bookRoom.startTime, r.startTime) >= 0) && (TimeSpan.Compare(bookRoom.startTime, r.endTime) <= 0))))    
        //                select r;
        //    if((DateTime.Compare(bookRoom.startDay, (DateTime)bookRoom.endDate) >0) || (TimeSpan.Compare(bookRoom.startTime,bookRoom.endTime) > 0))
        //    {
        //        massge = "Invalid date and time ";
        //    }
        //    else
        //    {
        //        if (check.Count() > 0)
        //        {
        //            massge = "Duplicate date and time";
        //        }
        //        else
        //        {
        //            if ((userRole == "User" && st == "Processing") || (userRole == "Admin"))
        //            {
        //                boookRoomEdit.personBookingId = bookRoom.personBookingId;
        //                boookRoomEdit.personalApprovedId = bookRoom.personalApprovedId;
        //                boookRoomEdit.roomId = bookRoom.roomId;
        //                boookRoomEdit.issue = bookRoom.issue;
        //                boookRoomEdit.startDay = bookRoom.startDay;
        //                boookRoomEdit.endDate = bookRoom.endDate;
        //                boookRoomEdit.startTime = bookRoom.startTime;
        //                boookRoomEdit.endTime = bookRoom.endTime;
        //                boookRoomEdit.createdTime = bookRoom.createdTime;
        //                boookRoomEdit.updatedTime = bookRoom.updatedTime;
        //                boookRoomEdit.status = bookRoom.status;
        //                boookRoomEdit.Users = bookRoom.Users;
        //                boookRoomEdit.Rooms = bookRoom.Rooms;

        //                await bookRoomRepository.UpdateAsync(boookRoomEdit);
        //                massge = "Update successful";
        //            }
        //            else
        //            {
        //                massge = "Update failed";
        //            }
        //        }
        //    }         
        //    return Ok(massge);
        //}

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
