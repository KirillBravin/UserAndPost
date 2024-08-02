using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAndPost.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User (int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User () { }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, email: {Email}";
        }
    }
}
