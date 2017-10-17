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
        private readonly User user;

        public CreateGoalCommand(IDatabase db, IModelFactory factory, User user)
        {
            this.db = db;
            this.factory = factory;
            this.user = user;
        }

        public string Execute(IList<string> commandLine)
        {
            try
            {
                int maxKcal = int.Parse(commandLine[0]);
                int maxWeight = int.Parse(commandLine[1]);
                var Goal = factory.CreateGoal(maxKcal, maxWeight);
                
            }
            catch
            {
                throw new ArgumentException("Goal could not be created!");
            }

            return $"Meal with ID {user.Goals.Count - 1} was created!";
        }
    }
}
