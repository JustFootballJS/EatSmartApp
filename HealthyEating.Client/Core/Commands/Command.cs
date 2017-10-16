using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Commands
{
    public abstract class Command : ICommand
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Command(IReader reader,IWriter writer)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
        }

        protected string ReadOneLine(string textToShow)
        {
            this.writer.Write(textToShow);
            return this.reader.Read();
        }

        public abstract string Execute(IList<string> commandLine);       
    }
}
