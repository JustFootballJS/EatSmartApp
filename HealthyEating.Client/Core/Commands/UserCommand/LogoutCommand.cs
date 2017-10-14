using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.UserCommand
{
    public class LogoutCommand : Command, ICommand
    {
        private readonly IUserManager userManager;
        public LogoutCommand(IReader reader, IWriter writer, IUserManager userManager)
            :base(reader,writer)
        {
            this.userManager = userManager;
        }
        public override string Execute(IList<string> commandLine)
        {
            return this.userManager.Logout();
        }
    }
}
