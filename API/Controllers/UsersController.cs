using System;
using System.IO;
using API.Models;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly string _path;
        // private IQueryDbService _queryDbService;

        public UsersController()
        {
            _path = Path.GetFullPath(ToString()!);
            // _queryDbService = _queryDbService 
        }

        [Authorize]
        [HttpGet("/{username}")]
        public User Get(string username)
        {
            var user = new User() {Username = username, Password = "password"};
            // var user = _queryDbService.GetUser();
            var piece = new ArtWork()
            {
                CustomerName = "Sammy",
                PieceName = "Mandala",
                CustomerContact = "s@s.com",
                DateFinished = DateTime.Now.Add(TimeSpan.FromDays(1)),
                DateStarted = DateTime.Now,
                MaterialCost = 10.00f,
                SalePrice = 300,
                ShippingCost = 2.00f,
                WidthInches = 30,
                Shape = "Round",
                TimeSpentMinutes = 500,
                IsCommission = true,
                PaymentType = "Credit Card",
                IsPaymentCollected = false
            };
            user.Pieces.Add(piece);
            return user;
        }

        [HttpPost]
        public void AddUser(UserInputModel userInput)
        {
            Console.WriteLine($"adding {userInput.Username}");
            // if (_queryDbService.CheckExisting(userInput.Username));
            //       throw new Exception("existing user");
            var user = new User(userInput.Username, userInput.Password);
            // _queryDbService.Save(user);
        }
        
        [Authorize]
        [HttpPut]
        public void EditUser(UserInputModel userInput)
        {
            Console.WriteLine($"changing {userInput.Username}");
            // if (_queryDbService.CheckExisting(userInput.Username));
            //       throw new Exception("existing user");
            var user = new User(userInput.Username, userInput.Password);
            // _queryDbService.Save(user);
        }
        
        [Authorize]
        [HttpDelete]
        public void DeleteUser(UserInputModel userInput)
        {
            Console.WriteLine($"deleting {userInput.Username}");
            // var user = _queryDbService.GetUser();
            // _queryDbService.Delete(user);
        }
    }
}