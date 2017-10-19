using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;


namespace HealthyEating.Client.Core.Commands
{
    public class RecoverAccountCommand : Command, ICommand
    {
        private readonly IUserManager userManager;

        public RecoverAccountCommand(IReader reader, IWriter writer, IUserManager userManager)
            : base(reader, writer)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();

            this.userManager = userManager;
        }
        public override string Execute()
        {
            var inputParameters = TakeInput();
            var username = inputParameters[0];
            var password = inputParameters[1];
            var answer = inputParameters[2];

            return userManager.RecoverAccount(username, password, answer);

        }
        private List<string> TakeInput()
        {
            var username = base.ReadOneLine("Username: ");
            var password = base.ReadOneLine("Password: ");
            var answer = base.ReadOneLine($"Some of your data may be impossible to recover {Environment.NewLine}because of the complexity of this operation.{Environment.NewLine} Do you release us from liability ? : ");

            return new List<string>() { username, password, answer };
        }
    }
}
