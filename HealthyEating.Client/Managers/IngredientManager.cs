using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           var ingredient= this.database.Ingredients.Single(x => x.Name == name);
            this.database.Ingredients.Remove(ingredient);
            this.database.SaveChanges();

            return "Deleted";
        }
    }
}
