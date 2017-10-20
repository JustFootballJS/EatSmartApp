using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System.Linq;

namespace HealthyEating.Client.Managers
{
    public class GoalManager:IGoalManager
    {
        private readonly IModelFactory modelFactory;
        private readonly IDatabase database;
        private readonly IUserManager userManager;

        public GoalManager(IModelFactory modelFactory, IDatabase database, IUserManager userManager)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(modelFactory, "modelFactory").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.modelFactory = modelFactory;
            this.database = database;
            this.userManager = userManager;
        }
        public string Create(string maxKcal, string wantedWeight)
        {
            var goal = this.modelFactory.CreateGoal(int.Parse(maxKcal), int.Parse(wantedWeight));
            var user = this.database.Users.Single(x => x.Id == this.userManager.LoggedUser.Id);
            this.userManager.LoggedUser.Goal = goal;
            user.Goal = goal;
            this.database.SaveChanges();
            return "Created goal";
        }
    }
}
