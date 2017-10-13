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
            this.commandFactory = commandFactory;
        }
        public ICommand ParseCommand(string commandLine)
        {

            var lineParameters = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];

            return this.commandFactory.CreateCommand(commandName);
        }
    }
}
