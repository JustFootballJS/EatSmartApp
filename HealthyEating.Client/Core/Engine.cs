using HealthyEating.Client.Core.Contracts;
using System;

namespace HealthyEating.Client.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandFactory commandFactory;
 

        public Engine(IReader reader, IWriter writer, ICommandFactory commandFactory)
        {
            this.reader = reader;
            this.writer = writer;
           
            this.commandFactory = commandFactory;

        }
        public void Run()
        {
            string commandLine = null;
            while ((commandLine = reader.Read()) != "exit")
            {
                try
                {
                    var command= this.commandFactory.CreateCommand(commandLine);
                    var result = command.Execute();

                    this.writer.WriteLine(result);

                    //var command = this.commandParser.ParseCommand(commandLine);
                    //if (command != null)
                    //{
                    //    this.commandProcessor.ProcessSingleCommand(command, commandLine);
                    //}
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
