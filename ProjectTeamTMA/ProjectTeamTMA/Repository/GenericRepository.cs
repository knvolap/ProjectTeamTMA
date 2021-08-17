using Microsoft.EntityFrameworkCore;
using ProjectTeamTMA.DBContexts;
using ProjectTeamTMA.Model;
using ProjectTeamTMA.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Repositor
{
    public class GenericRepository <T>: IGenericRepository<T> where T: class
    {   
        private readonly MyDBContext _context;

        public GenericRepository(MyDBContext context)
        {
           _context = context;
        }
        public IEnumerable<T> GetALL()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public async Task<T> AddAsync(T newEntity)
        {
            _context.Set<T>().Add(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }
        public async Task UpdateAsync(T UpdateEntity)
        {
            _context.Set<T>().Update(UpdateEntity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T DeleteEntity)
        {
            _context.Set<T>().Remove(DeleteEntity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> ListAsync()
        {

            return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<BookRoomViewModel>> ListAsync2()
        {
            var query = from br in _context.BookRooms
                        select new { br };
            List<BookRoomViewModel> result = await query.Select(x => new BookRoomViewModel()
            {
                Id = x.br.Id,
                personBookingId = x.br.personBookingId,
                roomId = x.br.roomId,
                issue = x.br.issue,
                startDay = x.br.startDay.ToString("dd/MM/yyyy"),
                endDate = x.br.endDate.HasValue ? x.br.endDate.Value.ToString("dd/MM/yyyy"):"",
                startTime = x.br.startTime.ToString("hh:mm"),
                endTime = x.br.endTime.HasValue ? x.br.endTime.Value.ToString("hh:mm") : "",
                createdTime = x.br.createdTime.ToString("dd/MM/yyyy:hh:mm"),
                updatedTime = x.br.updatedTime.HasValue ? x.br.endTime.Value.ToString("dd/MM/yyyy:hh:mm"): ""
            }).ToListAsync();
            return result;
        }
        public async Task<T> GetDetailAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        Task<T> IGenericRepository<T>.UpdateAsync(T UpdateEntity)
        {
            throw new NotImplementedException();
        }
        Task<T> IGenericRepository<T>.DeleteAsync(T DeleteEntity)
        {
            throw new NotImplementedException();
        }
        Task<IEnumerable<T>> IGenericRepository<T>.ListAsync()
        {
            throw new NotImplementedException();
        }

     
    }
}
