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
    public class DeleteGoalCommand //: Command,ICommand
    {
        private readonly IDatabase db;
        

        public DeleteGoalCommand(IReader reader, IWriter writer,IDatabase db)
            //:base( reader, writer)
        {
            //this.db = db;
            //this.user = user;
        }

        public string Execute()
        {
            //try
            //{
            //    int idToRemove = int.Parse(commandLine[0]);
            //    Goal goalToRemove = this.user.Goals.SingleOrDefault(g => g.Id == idToRemove);
            //    goalToRemove.isDeleted = true;
            //    return $"Goal with ID {goalToRemove.Id} is deleted!";
            //}
            //catch
            //{
            //    throw new ArgumentException("Enter a goal id to delete!");
            //}
            return null;
        }
    }
}
