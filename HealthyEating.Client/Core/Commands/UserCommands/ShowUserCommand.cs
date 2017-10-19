using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.UserCommands
{
    public class ShowUserCommand : Command, ICommand
    {
        private readonly IUserManager userManager;
        public ShowUserCommand(IReader reader, IWriter writer, IUserManager userManager)
            :base(reader,writer)
        {
            this.userManager = userManager;
        }
        public override string Execute()
        {
            return this.userManager.UserAsString(this.userManager.LoggedUser.Username);
        }
    }
}
