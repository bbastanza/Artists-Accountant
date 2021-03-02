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
        }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreatedAt { get; } = DateTime.Now;
        public virtual IList<ArtWork> Pieces { get; } = new List<ArtWork>();

        public double TotalUncollectedIncome
        {
            get
            {
                double total = 0;
                foreach (var piece in Pieces)
                {
                    if (!piece.IsPaymentCollected)
                        total += piece.SalePrice;
                }

                return total;
            }
        }
        
        public double TotalCollectedIncome
        {
            get
            {
                double total = 0;
                foreach (var piece in Pieces)
                {
                    if (piece.IsPaymentCollected)
                        total += piece.SalePrice;
                }

                return total;
            }
        }

        public double TotalExpenses
        {
            get
            {
                double total = 0;
                foreach (var piece in Pieces)
                {
                    total += piece.MaterialCost;
                    total += piece.ShippingCost;
                }

                return total;
            }
        }
    }
}