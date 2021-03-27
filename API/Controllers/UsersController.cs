using System;
using System.IO;
using API.Models;
using Core.Entities;
using Core.Services.JwtAuthentication;
using Core.Services.UserServices;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly IGetUserData _getUserData;
        private readonly IAddUser _addUser;
        private readonly IDeleteUser _deleteUser;
        private readonly IPatchUser _patchUser;
        private readonly IGenerateJwtToken _generateJwtToken;
        private readonly string _path;

        public UsersController(
            IGetUserData getUserData,
            IAddUser addUser,
            IDeleteUser deleteUser,
            IPatchUser patchUser,
            IGenerateJwtToken generateJwtToken)
        {
            _getUserData = getUserData;
            _addUser = addUser;
            _deleteUser = deleteUser;
            _patchUser = patchUser;
            _generateJwtToken = generateJwtToken;
            _path = Path.GetFullPath(ToString()!);
        }

        [Authorize]
        [HttpGet("{id}")]
        public UserModel Get(int? id)
        {
            if (id == null)
                throw new InvalidInputException(_path, "Get()");

            return new UserModel(_getUserData.GetUserWithArtworks(id));
        }

        [HttpPost]
        public UserAuthModel AddUser(UserInputModel userInput)
        {
            if (userInput.Username == null || userInput.Password == null)
                throw new InvalidInputException(_path, "Get()");

            _addUser.CreateUser(userInput.Username, userInput.Password);

            var user = _getUserData.GetDataByUsername(userInput.Username);

            var userModel = new UserAuthModel
            {
                Id  = user.Id,
                Username = user.Username,
                JwtToken = _generateJwtToken.NewUserToken(user)
            };
            
            return userModel;
        }

        // [Authorize]
        [HttpPatch]
        public void EditUser(UserInputModel userInput)
        {
            if (userInput.Id == null || userInput.Username == null && userInput.Password == null && userInput.ProfileImgUrl == null)
                throw new InvalidInputException(_path, "Patch()");

            var user = new User
            {
                Id = userInput.Id,
                Username = userInput.Username,
                Password = userInput.Password,
                ProfileImgUrl = userInput.ProfileImgUrl
            };
            
            _patchUser.Edit(user);
        }

        // [Authorize]
        [HttpDelete("{id}")]
        public void DeleteUser(int? id)
        {
            if (id == null)
                throw new InvalidInputException(_path, "Delete()");
            
            _deleteUser.Delete(id);
        }
    }
}
