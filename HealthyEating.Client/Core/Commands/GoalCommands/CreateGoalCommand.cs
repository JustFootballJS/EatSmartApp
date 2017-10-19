using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.GoalCommands
{
    public class CreateGoalCommand : ICommand
    {
        private readonly IDatabase db;
        private readonly IModelFactory factory;
        private readonly IUserManager userManager;

        public CreateGoalCommand(IDatabase db, IModelFactory factory, IUserManager userManager)
        {
            this.db = db;
            this.factory = factory;
            this.userManager = userManager;
        }

        public string Execute()
        {
            //this.userManager.LoggedUser.Username = "abvc";
            //this.db.Users.Single(x => x.Id == this.userManager.LoggedUser.Id).Username = "abvc";
            //this.db.SaveChanges();
            //Console.WriteLine(this.db.Users.Single(x => x.Id == this.userManager.LoggedUser.Id).Username);
            // Console.WriteLine();
            //try
            //{
            //    int maxKcal = int.Parse(commandLine[0]);
            //    int maxWeight = int.Parse(commandLine[1]);
            //    var Goal = factory.CreateGoal(maxKcal, maxWeight);

            //}
            //catch
            //{
            //    throw new ArgumentException("Goal could not be created!");
            //}

            //return $"Meal with ID {user.Goals.Count - 1} was created!";
            this.userManager.LoggedUser.Goal = new Goal() { WantedWeight = 20 };
            this.db.Users.Single(x => x.Id == this.userManager.LoggedUser.Id).Goal = new Goal() { WantedWeight = 10 };
            this.db.SaveChanges();
            return null;
        }
    }
}
