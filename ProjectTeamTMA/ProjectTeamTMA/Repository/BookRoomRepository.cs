using ProjectTeamTMA.DBContexts;
using ProjectTeamTMA.Model;
using ProjectTeamTMA.Repositor;
using ProjectTeamTMA.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Repository
{
    public class BookRoomRepository : GenericRepository<BookRoom>, IBookRoomRepository
    {
        public BookRoomRepository(MyDBContext context) : base(context)
        {
        }
    }
}
