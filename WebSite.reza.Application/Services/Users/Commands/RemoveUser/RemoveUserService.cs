using System;
using System.Linq;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;

        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long UserId)
        {
          //  var users = _context.Users.ToList();


            var user = _context.User.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشده"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };

        }
    }
}
