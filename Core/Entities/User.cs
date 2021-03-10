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
        }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual IList<ArtWork> ArtWorks { get; set; } = new List<ArtWork>();

        public double TotalUncollectedIncome
        {
            get
            {
                double total = 0;
                foreach (var piece in ArtWorks)
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
                foreach (var piece in ArtWorks)
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