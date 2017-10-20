using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Managers
{
    public class GoalManager:IGoalManager
    {
        private readonly IModelFactory modelFactory;
        private readonly IDatabase database;
        private readonly IUserManager userManager;

        public GoalManager(IModelFactory modelFactory, IDatabase database, IUserManager userManager)
        {
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
