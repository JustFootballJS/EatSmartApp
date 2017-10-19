using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthyEating.Client.Core.Commands
{
    public class LogInCommand : Command, ICommand
    {
        private readonly IUserManager userManager;
      

        public LogInCommand(IWriter writer, IReader reader, IUserManager userManager)
            :base(reader, writer)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
                  
            this.userManager = userManager;
        }

        public override string Execute()
        {
            var inputParameters = TakeInput();

            var username = inputParameters[0];
            var password = inputParameters[1];

            return this.userManager.LogIn(username, password);
         
           
        }

        private IList<string> TakeInput()
        {
            var username=this.ReadOneLine("Username: ");
            var password=this.ReadOneLine("Password: ");

            return new List<string>() { username, password };
        }
    }
}
