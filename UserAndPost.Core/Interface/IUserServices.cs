﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAndPost.Core.Models;

namespace UserAndPost.Core.Interface
{
    public interface IUserServices
    {
        void AddUser(User user);

        void DeleteUser(int id);

        List<User> GetAllUsers();

        void ModifyUser(User user);
    }
}
