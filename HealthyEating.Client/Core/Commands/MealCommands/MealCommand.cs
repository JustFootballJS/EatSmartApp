using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.MealCommands
{
    public abstract class MealCommand : Command, ICommand
    {
        private readonly IUserManager userManager;
        private readonly IModelFactory factory;
        private readonly IDatabase database;

        public MealCommand(IModelFactory factory, IReader reader, IWriter writer, IUserManager userManager, IDatabase database)
            : base(reader, writer)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();


            this.Factory = factory;
            this.UserManager = userManager;
            this.Database = database;
        }

        protected IUserManager UserManager { get; }
        protected IModelFactory Factory { get; }
        protected IWriter Writer { get; }
        protected IDatabase Database { get; set; }
        public abstract override string Execute();
    }
}
