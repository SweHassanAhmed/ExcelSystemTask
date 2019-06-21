using Data.Infrastructure;
using Data.Repository.Contracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
           : base(dbFactory) { }

        public User GetUserByName(string UserName)
        {
            return DbContext.Users.Where(a => a.IsActive == true && a.Name == UserName).FirstOrDefault();
        }
    }
}
