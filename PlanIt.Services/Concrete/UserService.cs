﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanIt.Entities;
using PlanIt.Repositories.Abstract;
using PlanIt.Services.Abstract;

namespace PlanIt.Services.Concrete
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepository repository) : base(repository)
        {
        }

        public User GetUserById(int id)
        {
            var user = _repository.GetSingle<User>(u => u.Id == id);

            return user;
        }

        public User GetUserExistByEmail(string email)
        {
            return _repository.GetSingle<User>(u => u.Email == email);
        }

        public int GetUserIdByEmail(string email)
        {
            return _repository.GetSingle<User>(u => u.Email == email).Id;
        }
        public List<string> GetUsersEmailsByEmailSubstringExceptCurrentUser(string emailSubstring, string currentUserEmail)
        {
            return _repository.Get<User>(u => u.Email.Contains(emailSubstring)).Select(u => u.Email).Where(email => email != currentUserEmail).ToList();
        }

        public User AddUser(User user)
        {
            return _repository.Insert<User>(user);
        }

        public bool UserExistsByEmail(string email)
        {
            return _repository.Exists<User>(u => u.Email == email);
        }
    }
}
