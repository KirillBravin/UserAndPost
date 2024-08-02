using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAndPost.Core.Interface;
using UserAndPost.Core.Models;

namespace UserAndPost.Core.Interface
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        void DeletePost(int id);
        List<Post> GetAllPosts();

        void ModifyPost(Post post);
    }
}
