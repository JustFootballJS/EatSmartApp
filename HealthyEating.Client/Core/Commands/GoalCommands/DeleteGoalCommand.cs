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
    public class DeleteGoalCommand : Command,ICommand
    {
        private readonly IDatabase db;
        private readonly IUserManager userManager;

        public DeleteGoalCommand(IReader reader, IWriter writer,IDatabase db,IUserManager userManager)
            :base( reader, writer)
        {
            this.db = db;
            this.userManager = userManager;
           
        }


        public override string Execute()
        {
            var user = this.db.Users.Single(x => x.Id == this.userManager.LoggedUser.Id);
            this.db.Goals.Remove(user.Goal);
            this.db.SaveChanges();
            return " Your goal has been successfully deleted!";
        }
    }
}
