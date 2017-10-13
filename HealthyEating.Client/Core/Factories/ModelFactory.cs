using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public Recipe CreateRecipe(string name, string ingredient)
        {
            return new Recipe() { Name = name, Ingredient = ingredient };
        }
    }
}
