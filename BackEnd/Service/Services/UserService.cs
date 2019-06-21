using Data.Infrastructure;
using Data.Repository.Contracts;
using Model.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository _userRepository, IUnitOfWork _unitOfWork)
        {
            userRepository = _userRepository;
            unitOfWork = _unitOfWork;
        }

        public User GetUserByName(string Name)
        {
            return userRepository.GetUserByName(Name);
        }

        public void CreateUser(User entity)
        {
            userRepository.Add(entity);
        }

        public void DeleteUser(int id, User entity)
        {
            userRepository.Delete(id, entity);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public void UpdateUser(int id, User entity)
        {
            var User = GetUserById(id);

            entity.IsActive = User.IsActive;
            entity.CreationDate = User.CreationDate;

            userRepository.Update(id, entity);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        
    }
}
