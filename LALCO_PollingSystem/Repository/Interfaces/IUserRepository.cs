using LALCO_PollingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALCO_PollingSystem.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User userToCreate);
        User Login(User loginUser);
    }
}
