using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public User()
        {
            Pieces = new List<Piece>();
            CreatedAt = DateTime.Now;
        }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual IList<Piece> Pieces { get; set; }

        public double TotalIncome
        {
            get
            {
                double total = 0;
                foreach (var piece in Pieces)
                {
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