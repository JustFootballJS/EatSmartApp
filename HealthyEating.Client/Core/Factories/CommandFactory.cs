using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();

            this.kernel = kernel;
        }

        public ICommand CreateCommand(string commandName)
        {
            try
            {
                return this.kernel.Get<ICommand>(commandName);

            }
            catch (Exception)
            {

                throw new ArgumentException("Wrong Command");
            }
        }
    }
}
