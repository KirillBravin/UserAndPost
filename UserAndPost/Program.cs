using System;
using UserAndPost.Core.Interface;
using UserAndPost.Core.Models;
using UserAndPost.Core.Repositories;
using UserAndPost.Core.Services;

namespace UserAndPost;

public class Program
{
    public static void Main(string[] args)
    {
        IService userAndPostServices = SetupdDependencies();

    }
    public static IService SetupdDependencies()
    {
        IPostRepository postRepository = new PostRepository("Server=localhost;Database=CarManagement;Trusted_Connection=True;");
        IUserRepository userRepository = new UserRepository("Server=localhost;Database=CarManagement;Trusted_Connection=True;");
        IPostServices postService = new PostServices(postRepository);
        IUserServices userServices = new UserServices(userRepository);
        return new AllServices(userServices, postService);
    }
}