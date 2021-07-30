
using ProjectTeamTMA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Interface
{
    public interface IIdentityService
    {
        ResponseToken Authentication(LoginModels loginModels);
    }
}
