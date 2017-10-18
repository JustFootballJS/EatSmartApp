using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private IWriter writer;

        public CommandProcessor(IWriter writer)
        {
            this.writer = writer;

            this.Commands = new List<ICommand>();
        }

        public ICollection<ICommand> Commands { get; set; }

        public void Add(ICommand command)
        {
            Commands.Add(command);
        }

        public void ProcessSingleCommand(ICommand command, string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();

            var result = command.Execute(lineParameters);

            this.writer.WriteLine(result);
        }
    }
}
