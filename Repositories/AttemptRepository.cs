using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.UserData
{
    public class AttemptRepository
    {
        string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=TestApp; Integrated Security=True";
        public void SetPointsToAttemptTable(string userLogin, string testName, int points)
        {
            var sqlQuery = @"INSERT INTO Attempts (TestName, UserLogin, Points, AttemptDate) VALUES(@TestName, @UserLogin, @Points, @AttemptDate)";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { UserLogin = userLogin, TestName = testName, Points = points, AttemptDate = DateTime.Now });
            }
        }
        public List<TestAttempt> GetAllResults()
        {
            var sqlQuery = @"SELECT * FROM Attempts";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var testAttempts = db.Query<TestAttempt>(sqlQuery);
                return testAttempts.ToList();
            }
        }
        public void DeleteAttempt(int attemptId)
        {
            var sqlQuery = "DELETE FROM Attempts WHERE AttemptId = @AttemptId";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { AttemptId = attemptId });
            }
        }
        public void MakeUserTeacher(int userId, bool IsTeacher)
        {
            var sqlQuery = "";
            if (IsTeacher)
            {
                sqlQuery = "UPDATE Users SET IsTeacher = 0 WHERE Id = @Id";
            }
            else
            {
                sqlQuery = "UPDATE Users SET IsTeacher = 1 WHERE Id = @Id";
            };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { Id = userId });
            }
        }
        public void MakeUserSuperAdmin(int userId, bool IsSuperAdmin)
        {
            var sqlQuery = "";
            if (IsSuperAdmin)
            {
                sqlQuery = "UPDATE Users SET IsSuperAdmin = 0 WHERE Id = @Id";
            }
            else
            {
                sqlQuery = "UPDATE Users SET IsSuperAdmin = 1 WHERE Id = @Id";
            }
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sqlQuery, new { Id = userId });
            }
        }
    }
}
