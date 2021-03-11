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

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string ProfileImgUrl { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual IList<ArtWork> ArtWorks { get; set; } 

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