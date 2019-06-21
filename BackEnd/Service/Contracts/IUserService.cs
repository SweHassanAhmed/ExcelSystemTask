using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface IUserService
    {
        User GetUserByName(string Name);
        // Marks an entity as new
        void CreateUser(User entity);

        // Marks an entity as modified
        void UpdateUser(int id, User entity);

        // Marks an entity to be removed
        void DeleteUser(int id, User entity);

        // Get an entity by int id
        User GetUserById(int id);

        // Gets all entities of type T
        List<User> GetAllUsers();

        // Save Changes
        void SaveUser();
    }
}
