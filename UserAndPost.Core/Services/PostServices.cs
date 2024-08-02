using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAndPost.Core.Interface;
using UserAndPost.Core.Models;

namespace UserAndPost.Core.Services
{
    public class PostServices : IPostServices
    {
        private readonly IPostRepository _postRepository;
        private List<Post> allPosts = new List<Post>();

        public PostServices (IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void AddPost(Post post)
        {
            _postRepository.AddPost(post);
        }

        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }

        public List<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        public void ModifyPost(Post post)
        {
            _postRepository.ModifyPost(post);
        }
    }
}
