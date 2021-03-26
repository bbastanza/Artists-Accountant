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

        public int? Id { get; }
        public string Username { get; }
        public string ProfileImgUrl { get; }
        public string JwtToken { get; set; }
        public IList<ArtWorkModel> ArtWorks { get; } = new List<ArtWorkModel>();
        public decimal? TotalMarginCollected => TotalCollectedIncome - TotalExpenses;
        public decimal? TotalMarginPotential => TotalCollectedIncome + TotalUncollectedIncome - TotalExpenses;

        public decimal? TotalUncollectedIncome
        {
            get
            {
                decimal? total = 0;
                foreach (var piece in ArtWorks)
                {
                    if (piece.IsPaymentCollected != null && 
                        !(bool) piece.IsPaymentCollected && 
                        piece.SalePrice != null)
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
                        && (bool) piece.IsPaymentCollected
                        && piece.SalePrice != null)
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
                    if (piece.MaterialCost == null &&
                        piece.ShippingCost == null) continue;
                    total += piece.MaterialCost;
                    total += piece.ShippingCost;
                }

                return total;
            }
        }
    }
}