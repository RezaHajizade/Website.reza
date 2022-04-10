﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebSite.reza.Application.Interfaces.Contexts;
//using WebSite.reza.Common;
//using WebSite.reza.Common.Dto;
//using WebSite.reza.Domain.Entities.Users;

//namespace WebSite.reza.Application.Services.Users.Commands.RegisterUser
//{
//    public interface IRegisterUserService
//    {
//        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
//    }

//    public class RegisterUserService : IRegisterUserService
//    {
//        private readonly IDataBaseContext _context;
//        public RegisterUserService(IDataBaseContext context)
//        {
//            _context = context;
//        }
//        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
//        {
//            try
//            {
//                if(string.IsNullOrWhiteSpace(request.Email))
//                {
//                    return new ResultDto<ResultRegisterUserDto>()
//                    {
//                        Data = new ResultRegisterUserDto()
//                        {
//                            UserId = 0,
//                        },
//                        IsSuccess = false,
//                        Message = "پست الکرترونیکی را وارد کنید"
//                    };
//                }

//                if(string.IsNullOrWhiteSpace(request.FullName))
//                {
//                    return new ResultDto<ResultRegisterUserDto>()
//                    {
//                        Data = new ResultRegisterUserDto()
//                        {
//                            UserId = 0,
//                        },
//                        IsSuccess = false,
//                        Message = "نام را وارد نمایید"
//                    };
//                }
//                if(string.IsNullOrWhiteSpace(request.Password))
//                {
//                    return new ResultDto<ResultRegisterUserDto>()
//                    {
//                        Data = new ResultRegisterUserDto()
//                        {
//                            UserId = 0,
//                        },
//                        IsSuccess = false,
//                        Message = "رمز عبور را وارد نمایید"
//                    };
//                }
//                if(request.Password!=request.RePassword)
//                {
//                    return new ResultDto<ResultRegisterUserDto>()
//                    {
//                        Data = new ResultRegisterUserDto()
//                        {
//                            UserId = 0,
//                        },
//                        IsSuccess = false,
//                        Message = "رمز عبور و تکرار آن باهم برابر نیست"
//                    };
//                }
//                //  string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";






//                var passwordHasher = new PasswordHasher();
//                var hashedPassword = passwordHasher.HashPassword(request.Password);

//                User user = new User
//                {
//                    FullName = request.FullName,
//                    Email = request.Email,
//                    Password=hashedPassword,
//                    IsActive=true
//                };


//                List<UserInRole> userInRoles = new List<UserInRole>();

//                foreach (var item in request.roles)
//                {
//                    var roles = _context.Role.Find(item.Id);
//                    userInRoles.Add(new UserInRole
//                    {
//                        Role = roles,
//                        RoleId = roles.RoleId,
//                        User = user,
//                        UserId = user.Id
//                    });

//                    user.UserInRoles = userInRoles;

//                    _context.User.Add(user);
//                    _context.SaveChanges();
//                }
//                return new ResultDto<ResultRegisterUserDto>()
//                {
//                    Data = new ResultRegisterUserDto()
//                    {
//                        UserId = user.Id,
//                    },
//                    IsSuccess = true,
//                    Message = "ثبت نام کاربر انجام شد.",

//                }; 
//            }
//            catch (Exception)
//            {
//                return new ResultDto<ResultRegisterUserDto>()
//                {
//                    Data = new ResultRegisterUserDto()
//                    {
//                        UserId = 0,
//                    },
//                    IsSuccess = false,
//                    Message = "ثبت نام انجام نشد !"
//                };
//            }
           
//        }
//    }

//    public class RequestRegisterUserDto
//    {
//        public string FullName { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public string  RePassword { get; set; }
//        public List<RoleInRegisterUserDto> roles { get; set; }
//    }

//    public class RoleInRegisterUserDto
//    {
//        public long Id { get; set; }
//    }

//    public class ResultRegisterUserDto
//    {
//        public long UserId { get; set; }

//    }
//}
