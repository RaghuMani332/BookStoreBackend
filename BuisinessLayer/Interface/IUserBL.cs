using ModelLayer.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interface
{
    public interface IUserBL
    {
       bool createUser(UserRequest request);
        String login(string userEmail, string password);
    }
}
