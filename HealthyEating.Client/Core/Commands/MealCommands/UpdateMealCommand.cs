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
    public class UpdateMealCommand : MealCommand, ICommand
    {
        public UpdateMealCommand(IModelFactory factory, IReader reader, IWriter writer, IUserManager userManager, IDatabase database) 
            : base(factory, reader, writer, userManager, database)
        {
        }

        public override string Execute()
        {
            int idOfMealToUpdate = int.Parse(base.ReadOneLine("Update meal with ID: "));
            var meal = new Meal { Id = idOfMealToUpdate };

            using (var ctx = new HealthyEatingContext())
            {
                ctx.Meals.Attach(meal);
            }

            return "";
        }
    }
}
