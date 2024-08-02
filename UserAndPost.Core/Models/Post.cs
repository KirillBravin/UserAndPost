using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAndPost.Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Post (int id, int userId, string title, string content)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Content = content;
        }

        public Post (int userId, string title, string content)
        {
            Title = title;
            Content = content;
        }

        public Post() { }

        public override string ToString()
        {
            return $"id: {Id}, user id: {UserId}, title: {Title}, content: {Content}";
        }
    }
}
