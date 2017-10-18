using HealthyEating.Client.Core.Contracts;
using System.Collections.Generic;


namespace HealthyEating.Client.Core.Commands.UserCommands
{
    public class LogoutCommand : Command, ICommand
    {
        private readonly IUserManager userManager;
        public LogoutCommand(IReader reader, IWriter writer, IUserManager userManager)
            : base(reader, writer)
        {
            this.userManager = userManager;
        }
        public override string Execute(IList<string> commandLine)
        {
            return this.userManager.Logout();
        }
    }
}
