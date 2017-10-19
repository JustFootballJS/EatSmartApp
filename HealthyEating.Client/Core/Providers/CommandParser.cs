using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            Guard.WhenArgument(commandFactory, "commandFactory").IsNull().Throw();

            this.commandFactory = commandFactory;
        }
        public ICommand ParseCommand(string commandLine)
        {
            Guard.WhenArgument(commandLine, "commandLine").IsNullOrEmpty().Throw();

            var lineParameters = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];

            return this.commandFactory.CreateCommand(commandName);
        }
    }
}
