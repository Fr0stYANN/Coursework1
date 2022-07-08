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
        public User GetUser(string login)
        {
            var sqlQuery = "Select * from Users where Login = @Login";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                var res = db.QueryFirstOrDefault<User>(sqlQuery, new { Login = login });
                return res;
            }
        }
        public List<User> GetAllUsers()
        {
            var sqlQuery = "SELECT * FROM Users";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<User>(sqlQuery);
                return result.ToList();
            }
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
        public void DeleteUser(int userId)
        {
            var sqlQuery = "DELETE FROM Users WHERE Id = @Id";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { Id = userId });
            }
        }
    }
}
