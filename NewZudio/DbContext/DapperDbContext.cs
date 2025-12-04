using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NewZudio.DbContext
{
    public class DapperDbContext
    {
        private readonly string _conectionString;
        public DapperDbContext()
        {
            _conectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_conectionString);
        }
    }
}