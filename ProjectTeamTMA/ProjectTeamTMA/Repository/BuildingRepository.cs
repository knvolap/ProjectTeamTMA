﻿using ProjectTeamTMA.DBContexts;
using ProjectTeamTMA.Model;
using ProjectTeamTMA.Repositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Repository
{
    public class BuildingRepository: GenericRepository<Building>
    {
        public BuildingRepository(MyDBContext context) : base(context)
        {
        }
    }
}
