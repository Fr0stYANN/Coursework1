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
        public void SetPointsToAttemptTable(string userLogin, string testName, int points)
        {
            var sqlQuery = @"INSERT INTO Attempts (TestName, UserLogin, Points, AttemptDate) VALUES(@TestName, @UserLogin, @Points, @AttemptDate)";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { UserLogin = userLogin, TestName = testName, Points = points, AttemptDate = DateTime.Now });
            }
        }
        public List<TestAttempt> GetAllResults()
        {
            var sqlQuery = @"SELECT * FROM Attempts";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                var testAttempts = db.Query<TestAttempt>(sqlQuery);
                return testAttempts.ToList();
            }
        }
        public void DeleteAttempt(int attemptId)
        {
            var sqlQuery = "DELETE FROM Attempts WHERE AttemptId = @AttemptId";
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { AttemptId = attemptId });
            }
        }
    }
}
