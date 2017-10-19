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
    public class DeleteMealCommand : ICommand
    {
        private readonly IDatabase db;
        private readonly User user;

        public DeleteMealCommand(IDatabase db, User user)
        {
            this.db = db;
            this.user = user;
        }

        public string Execute()
        {
            //try
            //{
            //    var idToRemove = int.Parse(commandLine[1]);
            //    var mealToRemove = this.user.Meals.SingleOrDefault(m => m.Id == idToRemove);
            //    mealToRemove.isDeleted = true;

            //    return $"Meal with ID {idToRemove} was deleted.";
            //}
            //catch
            //{
            //    throw new ArgumentException("Enter a meal id to delete!");
            //}
            return null;
        }
    }
}
