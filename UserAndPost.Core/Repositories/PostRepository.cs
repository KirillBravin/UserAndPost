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
    public class PostRepository : IPostRepository
    {
        private readonly string _dbConnectionString;

        public PostRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public void AddPost(Post post)
        {
            string sqlCommand = $"INSERT INTO Posts ([id], [user_id], [title], [content]) " +
                                $"VALUES (@Id, @UserId, @Title, @Content)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, post);
            }
        }

        public void DeletePost(int id)
        {
            string sqlCommand = $"DELETE FROM Posts WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, new { Id = id });
            }
        }

        public List<Post> GetAllPosts()
        {
            using IDbConnection connection = new SqlConnection(_dbConnectionString);
            connection.Open();
            List<Post> result = connection.Query<Post>($"SELECT id, user_id AS UserId, title AS Title, content AS Content " +
                                $"FROM [dbo].[Posts]").ToList();
            connection.Close();
            return result;
        }

        public void ModifyPost(Post post)
        {
            string sqlCommand = @"UPDATE Posts SET id = @Id, user_id = @UserId, 
                                title = @Title, content = @Content WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, post);
            }
        }
    }
}
