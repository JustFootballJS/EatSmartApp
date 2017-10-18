using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Commands
{
    public class ChangeCurrentWeightCommand : Command, ICommand
    {
        private readonly IUserManager userManager;

        public ChangeCurrentWeightCommand(IReader reader, IWriter writer, IUserManager userManager) :
            base(reader, writer)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();

            this.userManager = userManager;
        }
        public override string Execute(IList<string> commandLine)
        {
            var newWeight = double.Parse(TakeInput()[0]);

            return this.userManager.ChangeCurrentWeight(newWeight);
        }

        private IList<string> TakeInput()
        {
            var weight = this.ReadOneLine("Weight: ");

            return new List<string>() { weight };
        }
    }
}
