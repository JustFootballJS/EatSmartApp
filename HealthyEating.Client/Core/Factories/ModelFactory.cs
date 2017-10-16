using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Models;

namespace HealthyEating.Client.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public Recipe CreateRecipe(string name, string ingredient)
        {
            return new Recipe() { Name = name, Ingredient = ingredient };
        }

        public User CreateUser(string username, string password)
        {
            return new User() { Username = username, Password = password };
        }
    }
}
