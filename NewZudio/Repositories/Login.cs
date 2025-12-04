using Dapper;
using NewZudio.DbContext;
using NewZudio.Models.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NewZudio.Repositories
{
    public class Login : ILogin
    {
        private readonly DapperDbContext _context;
        public Login(DapperDbContext context)
        {
            _context = context;
        }
        public async Task<UserMaster> UserLogin(UserMaster obj)
        {
            try
            {
                using (var conn = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserID", obj.UserID);
                    parameters.Add("@Password",EncryptionManager.Encrypt(obj.Password));
                    parameters.Add("@Type", "Login");
                    parameters.Add("@UsID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    parameters.Add("@Name", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    parameters.Add("@Role", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                    parameters.Add("@VendorNumber", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                    parameters.Add("@Email", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    parameters.Add("@Phone", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
                    parameters.Add("@Flag", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                    await conn.ExecuteAsync("usp_Authentication",parameters,commandType: CommandType.StoredProcedure);
                    string flag = parameters.Get<string>("@Flag");
                    if (flag == "success")
                    {
                        return new UserMaster
                        {
                            Id = parameters.Get<int>("@UsID"),
                            Name = parameters.Get<string>("@Name"),
                            Role = parameters.Get<string>("@Role"),
                            VendorNo = parameters.Get<string>("@VendorNumber"),
                            Email = parameters.Get<string>("@Email"),
                            Phone = parameters.Get<string>("@Phone"),
                            Flag = flag
                        };
                    }
                    else
                    {
                        return new UserMaster { Flag = flag };
                    }
                }
            }
            catch (Exception ex)
            {
                return new UserMaster { Flag = "Error: " + ex.Message };
            }
        }

    }
}
