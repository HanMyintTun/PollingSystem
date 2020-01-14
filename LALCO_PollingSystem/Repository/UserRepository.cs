using LALCO_PollingSystem.Models;
using LALCO_PollingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LALCO_PollingSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private DBModel _db = new DBModel();

        //User Registration Function
        public bool CreateUser(User userToCreate)
        {
            bool isNewUser = false;
            try
            {
                var user = _db.Users.Where(x => x.UserName == userToCreate.UserName).FirstOrDefault();
                if (user == null)
                {
                    _db.Users.Add(userToCreate);
                    _db.SaveChanges();
                    isNewUser = true;
                }
                else
                {
                    isNewUser = false;
                }
            }
            catch (Exception ex)
            {
                isNewUser = false;
                Console.WriteLine(ex);
            }
            return isNewUser;
        }

        //User Login Function
        public User Login(User loginUser)
        {
            User user = new User();
            try
            {
                var validUser = (from c in _db.Users
                                 where c.UserName.Equals(loginUser.UserName)
                                 select c).FirstOrDefault();
                user = validUser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                user = null;
            }
            return user;
        }
    }
}