//using System.Collections.Generic;
//using System.Linq;
//using WebSite.reza.Application.Interfaces.Contexts;
//using WebSite.reza.Common;

//namespace WebSite.reza.Application.Services.Users.Queries.GetUsers
//{
//    public class GetUserService : IGetUsersService
//    {
//        private readonly IDataBaseContext _context;
//        public GetUserService(IDataBaseContext context)
//        {
//            _context = context;
//        }

//        public ResultGetUserDto Execute(RequestGetUserDto request)
//        {
//            var users = _context.User.AsQueryable();
//            if (!string.IsNullOrWhiteSpace(request.SearchKey))
//            {
//                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
//            }
//            int rowsCount = 0;
//            var usersList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
//            {

//                Email = p.Email,
//                FullName = p.FullName,
//                Id = p.Id,
//                IsActive = p.IsActive
//            }).ToList();

//            return new ResultGetUserDto
//            {
//                Rows = rowsCount,
//                Users = usersList,
//            };

//        }
//    }
//}
