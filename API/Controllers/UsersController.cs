using System;
using System.IO;
using API.Models;
using Core.Entities;
using Core.Services.UserServices;
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
        private readonly string _path;

        public UsersController(
            IGetUserData getUserData,
            IAddUser addUser,
            IDeleteUser deleteUser)
        {
            _getUserData = getUserData;
            _addUser = addUser;
            _deleteUser = deleteUser;
            _path = Path.GetFullPath(ToString()!);
        }

        //
        // TODO check all inputs for null
        //
        
        [Authorize]
        [HttpGet("/{username}")]
        public User Get(string username)
        {
            return _getUserData.GetUser(username);
        }

        [HttpPost]
        public void AddUser(UserInputModel userInput)
        {
            _addUser.Add(userInput.Username, userInput.Password);
        }

        [Authorize]
        [HttpPut]
        public void EditUser(UserInputModel userInput)
        {
            Console.WriteLine($"changing {userInput.Username}");
            var user = new User(userInput.Username, userInput.Password);
        }

        [Authorize]
        [HttpDelete]
        public void DeleteUser(UserInputModel userInput)
        {
            _deleteUser.Delete(userInput.Username);
        }
    }
}
// var piece = new ArtWork()
// {
//     CustomerName = "Sammy",
//     PieceName = "Mandala",
//     CustomerContact = "s@s.com",
//     DateFinished = DateTime.Now.Add(TimeSpan.FromDays(1)),
//     DateStarted = DateTime.Now,
//     MaterialCost = 10.00f,
//     SalePrice = 300,
//     ShippingCost = 2.00f,
//     WidthInches = 30,
//     Shape = "Round",
//     TimeSpentMinutes = 500,
//     IsCommission = true,
//     PaymentType = "Credit Card",
//     IsPaymentCollected = false
// };