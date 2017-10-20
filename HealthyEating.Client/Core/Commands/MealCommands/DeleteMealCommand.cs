using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.MealCommands
{
    public class DeleteMealCommand : MealCommand, ICommand
    {
        
        public DeleteMealCommand(IModelFactory factory, IReader reader, IWriter writer, IUserManager userManager, IDatabase database)
            : base(factory, reader, writer, userManager, database)
        {

        }
        
        public override string Execute()
        {
            //int mealId = int.Parse(base.ReadOneLine("Which Meal would you like to delete?"));
            //bool mealToDelete = UserManager.LoggedUser.Meals.SingleOrDefault(m => m.Id == mealId).isDeleted = false;
            //return $"Meal with Id {mealId} was deleted!";

            int idOfMealToDelete = int.Parse(base.ReadOneLine("Delete meal with ID: "));
            var meal = new Meal { Id = idOfMealToDelete };

            using (var ctx = new HealthyEatingContext())
            {
                ctx.Meals.Attach(meal);
                ctx.Meals.Remove(meal);
                ctx.SaveChanges();
            }

            return $"Meal with Id {idOfMealToDelete} was deleted!";
        }
    }
}
