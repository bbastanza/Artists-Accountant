using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public User()
        {
        }

        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime CreatedAt { get; } = DateTime.Now;
        public virtual IList<Piece> Pieces { get; } = new List<Piece>();

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