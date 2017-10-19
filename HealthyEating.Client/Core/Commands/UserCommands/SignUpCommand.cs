using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Commands
{
    public class SignUpCommand : Command, ICommand
    {
        private readonly IUserManager userManager;

        public SignUpCommand( IUserManager userManager, IReader reader, IWriter writer)
            : base(reader, writer)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
     
            this.userManager = userManager;           
        }

        public override string Execute()
        {
            var parameters = TakeInput();
            var username = parameters[0];
            var password = parameters[1];

            return this.userManager.SignUp(username, password);
        }

        private IList<string> TakeInput()
        {
            var username = ReadOneLine("Username: ");
           
            var password = ReadOneLine("Password: ");
            var confirmedPassword = this.ReadOneLine("Confirm Password: ");
            return new List<string>() { username, password };
        }
    }
}
