using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAndPost.Core.Interface;
using UserAndPost.Core.Models;
using UserAndPost.Core.Repositories;

namespace UserAndPost.Core.Services
{
    public class AllServices : IService
    {
        public IUserServices UserServices { get; private set; }
        public IPostServices PostServices { get; private set; }

        private List<Post> allPosts = new List<Post>();

        public AllServices(IUserServices userServices, IPostServices postServices)
        {
            UserServices = userServices;
            PostServices = postServices;
        }

        // Users
        public void AddUser(User user)
        {
            UserServices.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            UserServices.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return UserServices.GetAllUsers();
        }

        public void ModifyUser(User user)
        {
            UserServices.ModifyUser(user);
        }

        // Posts

        public void AddPost(Post post)
        {
            PostServices.AddPost(post);
        }

        public void DeletePost(int id)
        {
            PostServices.DeletePost(id);
        }

        public List<Post> GetAllPosts()
        {
            return PostServices.GetAllPosts();
        }

        public void ModifyPost(Post post)
        {
            PostServices.ModifyPost(post);
        }
    }
}
