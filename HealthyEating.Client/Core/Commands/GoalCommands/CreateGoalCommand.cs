using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.GoalCommands
{
    public class CreateGoalCommand : Command,ICommand
    {
        private readonly IDatabase db;
        private readonly IModelFactory factory;
   
        private readonly IGoalManager goalManager;

        public CreateGoalCommand(IReader reader, IWriter writer,IDatabase db, IModelFactory factory, IGoalManager goalManager)
            :base(reader,writer)
        {
            Guard.WhenArgument(db, "db").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(goalManager, "goalManager").IsNull().Throw();

            this.db = db;
            this.factory = factory;
            
            this.goalManager = goalManager;
        }

        public override string Execute()
        {
            var parameters = TakeInput();
            var maxkcal = parameters[0];
            var wantedWeight = parameters[1];

            return this.goalManager.Create(maxkcal, wantedWeight);
        }
        private IList<string> TakeInput()
        {
            var maxkcal = base.ReadOneLine("Max Kcal: ");
            var wantedweight = base.ReadOneLine("Wanted weight: ");
            return new List<string>() { maxkcal, wantedweight };
        }
    }
}
