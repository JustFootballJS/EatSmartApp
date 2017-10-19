using HealthyEating.Client.Core.Contracts;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Commands
{
    public class DeleteAccountCommand : Command, ICommand
    {
        private readonly IUserManager userManager;

        public DeleteAccountCommand(IReader reader, IWriter writer, IUserManager userManager)
            : base(reader, writer)
        {
            this.userManager = userManager;
        }
        public override string Execute(IList<string> commandLine)
        {
            var answer = TakeInput()[0];
            return this.userManager.DeleteAccount(answer);
        }
        private List<string> TakeInput()
        {
            var answer = base.ReadOneLine("Are you sure?");
            return new List<string>() { answer };
        }
    }
}
