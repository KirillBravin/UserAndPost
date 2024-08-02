using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAndPost.Core.Interface;
using UserAndPost.Core.Models;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;


namespace UserAndPost.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _dbConnectionString;
        public UserRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public void AddUser(User user)
        {
            string sqlCommand = $"INSERT INTO Users ([id], [name], [email]) " +
                                $"VALUES (@Id, @Name, @Email)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, user);
            }
        }

        public void DeleteUser(int id)
        {
            string sqlCommand = $"DELETE FROM Users WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, new { Id = id });
            }
        }

        public List<User> GetAllUsers()
        {
            using IDbConnection connection = new SqlConnection(_dbConnectionString);
            connection.Open();
            List<User> result = connection.Query<User>($"SELECT id AS Id, name AS Name, email as Email " +
                                $"FROM [dbo].[Users]").ToList();
            connection.Close();
            return result;
        }

        public void ModifyUser(User user)
        {
            string sqlCommand = @"UPDATE Users SET id = @Id, name = @Name, 
                                email = @Email WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, user);
            }
        }
    }
}
