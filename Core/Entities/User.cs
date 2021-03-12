using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User : Entity
    {
        public User()
        {
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            CreatedAt = DateTime.Now;
            ArtWorks = new List<ArtWork>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfileImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<ArtWork> ArtWorks { get; set; }
        public decimal TotalMarginCollected => TotalCollectedIncome - TotalExpenses;
        public decimal TotalMarginPotential => TotalCollectedIncome + TotalUncollectedIncome - TotalExpenses;

        public decimal TotalUncollectedIncome
        {
            get
            {
                decimal total = 0;
                foreach (var piece in ArtWorks)
                {
                    if (!piece.IsPaymentCollected)
                        total += piece.SalePrice;
                }

                return total;
            }
        }

        public decimal TotalCollectedIncome
        {
            get
            {
                decimal total = 0;
                foreach (var piece in ArtWorks)
                {
                    if (piece.IsPaymentCollected)
                        total += piece.SalePrice;
                }

                return total;
            }
        }

        public decimal TotalExpenses
        {
            get
            {
                decimal total = 0;
                foreach (var piece in ArtWorks)
                {
                    total += piece.MaterialCost;
                    total += piece.ShippingCost;
                }

                return total;
            }
        }

    }
}