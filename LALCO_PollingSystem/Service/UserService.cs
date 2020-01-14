using LALCO_PollingSystem.Models;
using LALCO_PollingSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scrypt;
namespace LALCO_PollingSystem.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //User Registration Function
        public bool CreateUser(User userToCreate)
        {
            bool isCreated = false;
            ScryptEncoder encoder = new ScryptEncoder();

            var pw = encoder.Encode(userToCreate.Password);//password hash

            userToCreate.Password = pw;
            userToCreate.IsAdmin = 0; // normal user for default
            try
            {
                isCreated = _userRepository.CreateUser(userToCreate);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                isCreated = false;
            }
            return isCreated;
        }

        //User Login Function
        public User Login(User loginUser)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            User user = new User();
            try
            {
                user = _userRepository.Login(loginUser);
                if(user != null)
                {
                    //if username exist, compare with hashed password
                    bool isValid = encoder.Compare(loginUser.Password, user.Password);
                    if (!isValid)
                        user = null;
                }
              
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