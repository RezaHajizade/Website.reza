using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
