using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Linq;

namespace HealthyEating.Client.Managers
{
    public class IngredientManager:IIngredientManager
    {
        private readonly IModelFactory modelFactory;
        private readonly IDatabase database;

        public IngredientManager(IModelFactory modelFactory, IDatabase database)
        {
            this.modelFactory = modelFactory;
            this.database = database;
        }
        public string Create(string name, string kcal, string protein, string fat, string fibre, string carbs)
        {
            var newIngredient= this.modelFactory.CreateIngredient(name, kcal,protein, fat, fibre, carbs);

            this.database.Ingredients.Add(newIngredient);
            this.database.SaveChanges();
            return $"Ingredient {name} was created";
        }

        public string Delete(string name)
        {
           var ingredient= this.database.Ingredients.SingleOrDefault(x => x.Name == name);
            if (ingredient == null)
            {
                throw new ArgumentException("Name is invalid");
            }
            this.database.Ingredients.Remove(ingredient);
            this.database.SaveChanges();

            return "Deleted";
        }
    }
}
