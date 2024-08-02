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
        private readonly IUserRepository _userRepository;
        private readonly IPostServices _postServices;

        private List<Post> allPosts = new List<Post>();

        public AllServices(IUserRepository userRepository, IPostServices postServices)
        {
            _userRepository = userRepository;
            _postServices = postServices;
        }

        // Users
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void ModifyUser(User user)
        {
            _userRepository.ModifyUser(user);
        }

        // Posts

        public void AddPost(Post post)
        {
            _postServices.AddPost(post);
        }

        public void DeletePost(int id)
        {
            _postServices.DeletePost(id);
        }

        public List<Post> GetAllPosts()
        {
            return _postServices.GetAllPosts();
        }

        public void ModifyPost(Post post)
        {
            _postServices.ModifyPost(post);
        }
    }
}
