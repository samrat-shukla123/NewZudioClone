using NewZudio.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace NewZudio.Repositories
{
    public interface ILogin
    {
        Task<UserMaster> UserLogin(UserMaster obj);
    }
}
