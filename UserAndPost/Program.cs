using System;
using System.Collections.Generic;
using UserAndPost.Core.Interface;
using UserAndPost.Core.Models;
using UserAndPost.Core.Repositories;
using UserAndPost.Core.Services;

namespace UserAndPost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IService userAndPostServices = SetupDependencies();
            List<User> allUsers = userAndPostServices.UserServices.GetAllUsers();
            List<Post> allPosts = userAndPostServices.PostServices.GetAllPosts();
            Console.WriteLine("Test");

            while (true)
            {
                Console.WriteLine("1. Users.");
                Console.WriteLine("2. Posts.");
                Console.WriteLine("0. Exit.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("1. Add user.");
                        Console.WriteLine("2. Delete user.");
                        Console.WriteLine("3. Show all users.");
                        Console.WriteLine("4. Modify user.");
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                Console.WriteLine("Input name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Input email: ");
                                string email = Console.ReadLine();
                                User newUser = new User(name, email);
                                userAndPostServices.UserServices.AddUser(newUser);
                                break;
                            case "2":
                                Console.WriteLine("Input user id: ");
                                int userToDelete = int.Parse(Console.ReadLine());
                                foreach (User user in allUsers)
                                {
                                    if (user.Id == userToDelete)
                                    {
                                        userAndPostServices.UserServices.DeleteUser(userToDelete);
                                        Console.WriteLine("User deleted.");
                                        break;
                                    }
                                }
                                break;
                            case "3":
                                allUsers = userAndPostServices.UserServices.GetAllUsers();
                                foreach (User user in allUsers)
                                {
                                    Console.WriteLine(user);
                                }
                                break;
                            case "4":
                                allUsers = userAndPostServices.UserServices.GetAllUsers();
                                Console.WriteLine("Please enter user ID: ");
                                int userToModify = int.Parse(Console.ReadLine());
                                User newModifiedUser = allUsers.FirstOrDefault(x => x.Id == userToModify);
                                if (newModifiedUser == null)
                                {
                                    Console.WriteLine("User not found.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("New name: ");
                                    newModifiedUser.Name = Console.ReadLine();
                                    Console.WriteLine("New email: ");
                                    newModifiedUser.Email = Console.ReadLine();

                                    userAndPostServices.UserServices.ModifyUser(newModifiedUser);
                                    Console.WriteLine("User parameters were updated.");
                                }

                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("1. Add post.");
                        Console.WriteLine("2. Delete post.");
                        Console.WriteLine("3. Show all posts.");
                        Console.WriteLine("4. Modify post.");
                        string postInput = Console.ReadLine();
                        switch (postInput)
                        {
                            case "1":
                                Console.WriteLine("Input user post id: ");
                                int newUserPostId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Input title: ");
                                string newTitle = Console.ReadLine();
                                Console.WriteLine("Input content: ");
                                string newContent = Console.ReadLine();
                                Post newPost = new Post(newUserPostId, newTitle, newContent);
                                userAndPostServices.PostServices.AddPost(newPost);
                                break;
                            case "2":
                                Console.WriteLine("Input post id: ");
                                int postToDelete = int.Parse(Console.ReadLine());
                                foreach (Post post in allPosts)
                                {
                                    if (post.Id == postToDelete)
                                    {
                                        userAndPostServices.PostServices.DeletePost(postToDelete);
                                        Console.WriteLine("post deleted.");
                                        break;
                                    }
                                }
                                break;
                            case "3":
                                allPosts = userAndPostServices.PostServices.GetAllPosts();
                                foreach (Post post in allPosts)
                                {
                                    Console.WriteLine(post);
                                }
                                break;
                            case "4":
                                allPosts = userAndPostServices.PostServices.GetAllPosts();
                                Console.WriteLine("Please enter post ID: ");
                                int postToModify = int.Parse(Console.ReadLine());
                                Post newModifiedPost = allPosts.FirstOrDefault(x => x.Id == postToModify);
                                if (newModifiedPost == null)
                                {
                                    Console.WriteLine("Post not found.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("New user post id: ");
                                    newModifiedPost.UserId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("New title: ");
                                    newModifiedPost.Title = Console.ReadLine();
                                    Console.WriteLine("New content: ");
                                    newModifiedPost.Content = Console.ReadLine();

                                    userAndPostServices.PostServices.ModifyPost(newModifiedPost);
                                    Console.WriteLine("Post updated.");
                                }
                                break;
                        }
                        break;
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }

        }
        public static IService SetupDependencies()
        {
            IPostRepository postRepository = new PostRepository("Server=localhost;Database=UsersAndPosts;Trusted_Connection=True;TrustServerCertificate=True;");
            IUserRepository userRepository = new UserRepository("Server=localhost;Database=UsersAndPosts;Trusted_Connection=True;TrustServerCertificate=True;");
            IPostServices postService = new PostServices(postRepository);
            IUserServices userServices = new UserServices(userRepository);
            return new AllServices(userServices, postService);
        }
    }
}