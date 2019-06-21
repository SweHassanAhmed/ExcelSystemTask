using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Models;
using Service.Contracts;

namespace WebAPI.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Route("api/Users")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }

        /// <summary>
        /// Get All The User Data
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsers")]
        public IActionResult GetAll()
        {
            var ListOfUsers = userService.GetAllUsers();
            List<UserDTO> MappedUsers = new List<UserDTO>();

            if (ListOfUsers != null)
                MappedUsers = mapper.Map<List<UserDTO>>(ListOfUsers);

            return Ok(MappedUsers);
        }

        /// <summary>
        /// Creating New User
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostUser([FromBody]UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var ListOfError = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                return BadRequest(ListOfError);
            }

            var mappedUser = mapper.Map<User>(userDTO);

            userService.CreateUser(mappedUser);
            userService.SaveUser();

            return Ok(userDTO);
        }

        /// <summary>
        /// Update User Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody]UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var ListOfError = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                return BadRequest(ListOfError);
            }

            var mappedUser = mapper.Map<User>(userDTO);

            userService.UpdateUser(id, mappedUser);
            userService.SaveUser();

            return Ok(userDTO);
        }

        /// <summary>
        /// Get Specific User By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            User user = userService.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }
            var mappedUser = mapper.Map<UserDTO>(user);
            return Ok(mappedUser);
        }

        /// <summary>
        /// Delete User By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = userService.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }

            userService.DeleteUser(id,user);
            userService.SaveUser();

			return StatusCode((int)HttpStatusCode.NoContent);
        }


    }

}