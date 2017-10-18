using HealthyEating.Client.Core.Contracts;
using System;

namespace HealthyEating.Client.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser commandParser;
        private readonly ICommandProcessor commandProcessor;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser, ICommandProcessor commandProcessor)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.commandProcessor = commandProcessor;

        }
        public void Run()
        {
            string commandLine = null;
            while ((commandLine = reader.Read()) != "exit")
            {
                try
                {
                    var command = this.commandParser.ParseCommand(commandLine);
                    if (command != null)
                    {
                        this.commandProcessor.ProcessSingleCommand(command, commandLine);
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    this.writer.WriteLine(string.Format("ERROR: {0}", ex.Message));
                }
            }
        }
    }
}
