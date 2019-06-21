using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByName(string UserName);
    }
}
