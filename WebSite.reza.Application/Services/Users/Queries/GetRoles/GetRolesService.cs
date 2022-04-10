using System.Collections.Generic;
using System.Linq;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService: IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Role.ToList().Select(p => new RolesDto
            {
                Id = p.RoleId,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }      
    }
}
