using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    public class UserRepository
    {
        string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=TestApp; Integrated Security=True";
        public bool CheckUserExists(string password, string login)
        {
            var sqlQuery = "Select * from Users where Login = @Login and Password = @Password";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var res = db.QueryFirstOrDefault(sqlQuery, new { Login = login, Password = password });
                if(res == null)
                {
                    return false;
                }
            }
            return true;
        }
        public int RegisterUser(string password, string login)
        {
            var sqlQuery = "Insert into Users (Login, Password) Values (@Login,@Password)";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { Login = login, Password = password });
            }
            return 1;
        }
        public int SetPoints(int points, string login)
        {
            var sqlQuery = "UPDATE Users SET Points = @Points WHERE Login = @Login";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { Points = points, Login = login });
            }
            return 1;
        }
    }
}
