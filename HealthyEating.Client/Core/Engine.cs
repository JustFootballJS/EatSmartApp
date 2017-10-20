using Bytes2you.Validation;
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
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(commandFactory, "commandFactory").IsNull().Throw();



            this.reader = reader;
            this.writer = writer;
           
            this.commandFactory = commandFactory;

        }
        public void Run()
        {
            string commandLine = null;
            while ((commandLine = string.Join("",reader.Read().ToLower().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries))) != "exit")
            {
                try
                {
                    var command= this.commandFactory.CreateCommand(commandLine);
                    var result = command.Execute();

                    this.writer.WriteLine(result);

                    
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    this.writer.WriteLine( ex.Message);
                }
            }
        }
    }
}
