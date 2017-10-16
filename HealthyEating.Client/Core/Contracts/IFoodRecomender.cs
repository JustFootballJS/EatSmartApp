using HealthyEating.Client.Models;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IFoodRecomender
    {
        ICollection<Recipe> RecommendFullPortions(decimal maxCalories, string nutrition);

        ICollection<Recipe> RecommendNotFullPortions(decimal maxCalories, string nutrition);
    }
}
