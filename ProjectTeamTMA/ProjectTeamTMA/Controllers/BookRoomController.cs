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
        public async Task<ActionResult<IEnumerable<BookRoom>>> List1()
        {
            var model1 = await bookRoomRepository.ListAsync();
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
                    status = model.status,
                    startDay = model.startDay.ToString("dd/MM/yyyy"),
                    endDate = model.endDate.ToString("dd/MM/yyyy"),
                    startTime = model.startTime.ToString(),
                    endTime = model.endTime.ToString(),
                    createdTime = model.createdTime.ToString("dd/MM/yyyy"),
                    updatedTime = model.updatedTime.ToString("dd/MM/yyyy")
                };
                model2.Add(book);
            }
            return Ok(model2);
        }





        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Create2([FromBody] BookRoomViewModel model)
        {
            string massge = "";
            BookRoom bookRoom = new BookRoom();
            var startDayBr = DateTime.Parse(model.startDay);
            var endDateBr = DateTime.Parse(model.endDate);
            var starTimebr = TimeSpan.Parse(model.startTime);
            var endTimeBr = TimeSpan.Parse(model.endTime);

            var query1 = (from br in myDbContext.BookRooms
                          where br.roomId == model.roomId
                          select new { br.startDay, br.endDate, br.startTime, br.endTime }).ToList();

            foreach (var item in query1)
            {
                if (item.endDate > startDayBr)
                {
                    massge = "Please enter the Day time";
                   
                }
                else if (startDayBr >= endDateBr)
                {
                    massge = "Please enter the Day time";
                }
                //else if (item.endTime > starTimebr)
                //{
                //    return Redirect("Please enter the Day time");
                //}
                else if (starTimebr >= endTimeBr)
                {
                    massge = "Please enter the Day time";
                }
                else
                {
                    bookRoom.personBookingId = model.personBookingId;
                    bookRoom.roomId = model.roomId;
                    bookRoom.issue = model.issue;
                    bookRoom.startDay = DateTime.Parse(model.startDay);
                    bookRoom.endDate = DateTime.Parse(model.endDate);
                    bookRoom.startTime = TimeSpan.Parse(model.startTime);
                    bookRoom.endTime = TimeSpan.Parse(model.endTime);
                    bookRoom.createdTime = DateTime.Parse(model.createdTime);
                    bookRoom.updatedTime = DateTime.Parse(model.updatedTime);
                    massge = "Create successful";
                }
            }
            await bookRoomRepository.AddAsync(bookRoom);
            return Ok(massge);
        }

      

        [Authorize(Roles = "User,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookRoomViewModel bookRoom)
        {
            string massge = "";
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userRole = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;
            var boookRoomEdit = myDbContext.BookRooms.Where(b => b.Id == id).FirstOrDefault();
            string st = boookRoomEdit.status;
            var check = from r in myDbContext.BookRooms
                        where ((r.roomId == bookRoom.roomId)
                        && (r.Id != id)
                        && (((DateTime.Compare(r.startDay, DateTime.Parse(bookRoom.startDay)) >= 0) && (DateTime.Compare(r.startDay, DateTime.Parse(bookRoom.endDate)) < 0)) || ((DateTime.Compare(DateTime.Parse(bookRoom.startDay), r.startDay) >= 0) && (DateTime.Compare(DateTime.Parse(bookRoom.startDay), (DateTime)r.endDate) < 0)))
                        && (((TimeSpan.Compare(r.startTime, TimeSpan.Parse(bookRoom.startTime)) >= 0) && (TimeSpan.Compare(r.startTime, TimeSpan.Parse(bookRoom.endTime)) < 0)) || ((TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), r.startTime) >= 0) && (TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), r.endTime) < 0))))
                        select r;
            if ((DateTime.Compare(DateTime.Parse(bookRoom.startDay), DateTime.Parse(bookRoom.endDate)) > 0) || (TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), TimeSpan.Parse(bookRoom.endTime)) > 0))
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
                    if ((userRole == "User" && st == "Processing"))
                    {
                        boookRoomEdit.roomId = bookRoom.roomId;
                        boookRoomEdit.issue = bookRoom.issue;
                        boookRoomEdit.startDay = DateTime.Parse(bookRoom.startDay);
                        boookRoomEdit.endDate = DateTime.Parse(bookRoom.endDate);
                        boookRoomEdit.startTime = TimeSpan.Parse(bookRoom.startTime);
                        boookRoomEdit.endTime = TimeSpan.Parse(bookRoom.endTime);
                        boookRoomEdit.createdTime = DateTime.Parse(bookRoom.createdTime);
                        boookRoomEdit.updatedTime = DateTime.Parse(bookRoom.updatedTime);
                        await bookRoomRepository.UpdateAsync(boookRoomEdit);
                        massge = "Update successful";
                    }
                    else if (userRole == "Admin")
                    {
                        bookRoom.personBookingId = bookRoom.personBookingId;
                        boookRoomEdit.personalApprovedId = bookRoom.personalApprovedId;
                        boookRoomEdit.roomId = bookRoom.roomId;
                        boookRoomEdit.issue = bookRoom.issue;
                        boookRoomEdit.startDay = DateTime.Parse(bookRoom.startDay);
                        boookRoomEdit.endDate = DateTime.Parse(bookRoom.endDate);
                        boookRoomEdit.startTime = TimeSpan.Parse(bookRoom.startTime);
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

     

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(BookRoom bookRoom)
        {
            await bookRoomRepository.DeleteAsync(bookRoom);
            return Ok(bookRoom.Id);
        }

        ////[Authorize(Roles = "User,Admin")]
        //[HttpPost("BookRoom1")]
        //public async Task<IActionResult> Create1(BookRoomViewModel model)
        //{
        //    string massge = "";
        //    BookRoom bookRoom = new BookRoom();
        //    var startDayBr = DateTime.Parse(model.startDay);
        //    var endDateBr = DateTime.Parse(model.endDate);

        //    if (startDayBr > endDateBr)
        //    {
        //        massge = "Please enter the Day time";
        //    }
        //    else
        //    {
        //        bookRoom.personBookingId = model.personBookingId;
        //        bookRoom.roomId = model.roomId;
        //        bookRoom.issue = model.issue;
        //        bookRoom.startDay = DateTime.Parse(model.startDay);
        //        bookRoom.endDate = DateTime.Parse(model.endDate);
        //        bookRoom.startTime = TimeSpan.Parse(model.startTime);
        //        bookRoom.endTime = TimeSpan.Parse(model.endTime);
        //        bookRoom.createdTime = DateTime.Parse(model.createdTime);
        //        bookRoom.updatedTime = DateTime.Parse(model.updatedTime);
        //    }
        //    await bookRoomRepository.AddAsync(bookRoom);
        //    return Ok(bookRoom.Id);
        //}

        ////[Authorize(Roles = "Admin")]
        //[HttpPut("Admin/{id}")]
        //public async Task<IActionResult> BookRoomApproved(BookRoomViewModel model, Guid id)
        //{
        //    var bookRoom = await myDbContext.BookRooms.FindAsync(id);
        //    bookRoom.Id = model.Id;
        //    bookRoom.personalApprovedId = model.personalApprovedId;
        //    bookRoom.personBookingId = model.personBookingId;
        //    bookRoom.roomId = model.roomId;
        //    bookRoom.issue = model.issue;
        //    bookRoom.status = model.status = "Accept";
        //    bookRoom.startDay = DateTime.Parse(model.startDay);
        //    bookRoom.endDate = DateTime.Parse(model.endDate);
        //    bookRoom.startTime = TimeSpan.Parse(model.startTime);
        //    bookRoom.endTime = TimeSpan.Parse(model.endTime);
        //    bookRoom.createdTime = DateTime.Parse(model.createdTime);
        //    bookRoom.updatedTime = DateTime.Parse(model.updatedTime);
        //    await bookRoomRepository.UpdateAsync(bookRoom);
        //    return Ok(bookRoom);
        //}
        //// status = Accept and Reject

        //[Authorize(Roles = "User")]
        //[HttpPut("User/{id}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] BookRoomViewModel bookRoom)
        //{
        //    string massge = "";
        //    var claimsIdentity = this.User.Identity as ClaimsIdentity;
        //    var userRole = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;
        //    var boookRoomEdit = myDbContext.BookRooms.Where(b => b.Id == id).FirstOrDefault();
        //    string st = bookRoom.status;
        //    var check = from r in myDbContext.BookRooms
        //                where ((r.roomId == bookRoom.roomId)
        //                && (r.Id != id)
        //                && (((DateTime.Compare(r.startDay, DateTime.Parse(bookRoom.startDay)) >= 0) && (DateTime.Compare(r.startDay, DateTime.Parse(bookRoom.endDate)) <= 0)) || ((DateTime.Compare(DateTime.Parse(bookRoom.startDay), r.startDay) >= 0) && (DateTime.Compare(DateTime.Parse(bookRoom.startDay), (DateTime)r.endDate) <= 0)))
        //                && (((TimeSpan.Compare(r.startTime, TimeSpan.Parse(bookRoom.startTime)) >= 0) && (TimeSpan.Compare(r.startTime, TimeSpan.Parse(bookRoom.endTime)) <= 0)) || ((TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), r.startTime) >= 0) && (TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), r.endTime) <= 0))))
        //                select r;
        //    if ((DateTime.Compare(DateTime.Parse(bookRoom.startDay), DateTime.Parse(bookRoom.endDate)) > 0) || (TimeSpan.Compare(TimeSpan.Parse(bookRoom.startTime), TimeSpan.Parse(bookRoom.endTime)) > 0) || (DateTime.Compare(DateTime.Parse(bookRoom.startDay), DateTime.Now) < 0))
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
        //                boookRoomEdit.startDay = DateTime.Parse(bookRoom.startDay);
        //                boookRoomEdit.endDate = DateTime.Parse(bookRoom.endDate);
        //                boookRoomEdit.startTime = TimeSpan.Parse(bookRoom.startTime);
        //                boookRoomEdit.endTime = TimeSpan.Parse(bookRoom.endTime);
        //                boookRoomEdit.createdTime = DateTime.Parse(bookRoom.createdTime);
        //                boookRoomEdit.updatedTime = DateTime.Parse(bookRoom.updatedTime);
        //                boookRoomEdit.status = bookRoom.status;
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
    }
}

