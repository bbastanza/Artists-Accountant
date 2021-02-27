using System;
using System.IO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly string _path;

        public UsersController()
        {
            _path = Path.GetFullPath(ToString()!);
        }

        [HttpGet]
        public User Get()
        {
            var user = new User() {UserName = "Brian", Password = "password", Email = "myEmail"};
            var piece = new Piece()
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
    }
}