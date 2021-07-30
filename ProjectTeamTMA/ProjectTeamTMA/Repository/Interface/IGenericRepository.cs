using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Repository.Interface
{
   public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T newEntity);
        Task<T> UpdateAsync(T UpdateEntity);
        Task<T> DeleteAsync(T DeleteEntity);
        Task<T> GetDetailAsync(object id);
        Task<IEnumerable<T>> ListAsync();

        //Task<IEnumerable<Task>> GetTaskList();
        //Task<Task> Create(Task task);
        //Task<Task> Update( Task task);
        //Task<Task> Delete(Guid id);
        //Task<Task> GetById(Guid id);

    }
}
