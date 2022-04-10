using System.Collections.Generic;

namespace WebSite.reza.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUserDto
    {
       public  List<GetUsersDto> Users { get; set; }
       public int Rows { get; set; }
    }
}
