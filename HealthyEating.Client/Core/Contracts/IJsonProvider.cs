using HealthyEating.Client.Models;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IJsonProvider
    {
        ICollection<Ingredient> SeedIngredients(string fileName);
    }
}
