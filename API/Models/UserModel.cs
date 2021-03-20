using System.Collections.Generic;
using Core.Entities;

namespace API.Models
{
    public class UserModel
    {
        public UserModel(User user)
        {
            Username = user.Username;
            ProfileImgUrl = user.ProfileImgUrl;
            Id = user.Id;
            foreach (var artwork in user.ArtWorks)
            {
                ArtWorks.Add(new ArtWorkModel(artwork));
            }
        }

        public int? Id { get; set; }
        public string Username { get; set; }
        public string ProfileImgUrl { get; set; }
        public IList<ArtWorkModel> ArtWorks { get; set; } = new List<ArtWorkModel>();
        public decimal? TotalMarginCollected => TotalCollectedIncome - TotalExpenses;
        public decimal? TotalMarginPotential => TotalCollectedIncome + TotalUncollectedIncome - TotalExpenses;

        public decimal? TotalUncollectedIncome
        {
            get
            {
                decimal? total = 0;
                foreach (var piece in ArtWorks)
                {
                    if (piece.IsPaymentCollected != null
                        && !(bool) piece.IsPaymentCollected)
                        total += piece.SalePrice;
                }

                return total;
            }
        }

        public decimal? TotalCollectedIncome
        {
            get
            {
                decimal? total = 0;
                foreach (var piece in ArtWorks)
                {
                    if (piece.IsPaymentCollected != null
                        && (bool) piece.IsPaymentCollected)
                        total += piece.SalePrice;
                }

                return total;
            }
        }

        public decimal? TotalExpenses
        {
            get
            {
                decimal? total = 0;
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