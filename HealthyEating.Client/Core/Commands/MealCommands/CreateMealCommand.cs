using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyEating.Client.Core.Factories;
using HealthyEating.Client.Utils;
using Bytes2you.Validation;
using System.ComponentModel.Design;

namespace HealthyEating.Client.Core.Commands.MealCommands
{
    class CreateMealCommand : Command, ICommand
    {
        private readonly IDatabase db;
        private readonly IUserManager userManager;
        private readonly IModelFactory factory;

        public CreateMealCommand(IModelFactory factory, IReader reader, IWriter writer, IUserManager userManager, IDatabase database)
            : base( reader, writer)
        {
            this.db = database;
            this.userManager = userManager;
            this.factory = factory;
        }

        public override string Execute()
        {

            MealCategory mealCategory = (MealCategory)MealCategory.Parse(typeof(MealCategory), 
                base.ReadOneLine("Breakfast/Lunch/Supper: ").ToLower());
            DateTime mealDate = Convert.ToDateTime(base.ReadOneLine("When did you eat it? (DD/MM/YYYY): "));
            string recipeToAdd = ReadOneLine("What did you eat?: ");
            List<Recipe> listOfRecipesToAdd = new List<Recipe>();

            do
            {
                listOfRecipesToAdd.Add(this.db.Recipes.SingleOrDefault(r => r.Name == recipeToAdd&&r.User.Id==this.userManager.LoggedUser.Id));
                recipeToAdd = ReadOneLine("What did you eat?: ");
            }
            while (recipeToAdd != "");
            
            Meal meal = this.factory.CreateMeal(mealCategory, mealDate, listOfRecipesToAdd);    
            var user = this.db.Users.Single(x => x.Id == this.userManager.LoggedUser.Id);
            meal.User = user;
            this.db.Meals.Add(meal);
            this.db.SaveChanges();
           
            return $"Meal with with {string.Join(",",meal.Recipes.Select(x=>x.Name).ToArray())} was created!";
        }
    }
}
