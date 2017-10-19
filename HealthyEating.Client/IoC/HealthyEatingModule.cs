using HealthyEating.Client.Core;
using HealthyEating.Client.Core.Commands;
using HealthyEating.Client.Core.Commands.GoalCommands;
using HealthyEating.Client.Core.Commands.RecomendCommands;
using HealthyEating.Client.Core.Commands.UserCommands;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Core.Factories;
using HealthyEating.Client.Core.Providers;
using HealthyEating.Client.Data;
using HealthyEating.Client.Managers;
using Ninject.Modules;

namespace HealthyEating.Client.IoC
{
    public class HealthyEatingModule : NinjectModule
    {
            
        public override void Load()
        {           
            this.Bind<IReader>().To<Reader>().InSingletonScope();
            this.Bind<IWriter>().To<Writer>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            
            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IModelFactory>().To<ModelFactory>();
            this.Bind<IFoodRecomender>().To<FoodRecommender>();
            this.Bind<IUserManager>().To<UserManager>().InSingletonScope();
            this.Bind<IDatabase>().To<HealthyEatingContext>();
            this.Bind<IPasswordHasher>().To<PasswordHasher>();

            this.Bind<ICommand>().To<CreateRecipeCommand>().Named("createrecipe");
            this.Bind<ICommand>().To<ListRecipesCommand>().Named("listrecipes");
            this.Bind<ICommand>().To<ChangeCurrentWeightCommand>().Named("changecurrentweight");
            this.Bind<ICommand>().To<DeleteAccountCommand>().Named("deleteaccount");
            this.Bind<ICommand>().To<LogInCommand>().Named("login");
            this.Bind<ICommand>().To<LogoutCommand>().Named("logout");
            this.Bind<ICommand>().To<RecoverAccountCommand>().Named("recoveraccount");
            this.Bind<ICommand>().To<SignUpCommand>().Named("signup");
            this.Bind<ICommand>().To<RecommendFullPortionsCommand>().Named("recommendfullportions");
            this.Bind<ICommand>().To<RecommendNotFullPortionsCommand>().Named("recommendnotfullportions");
            this.Bind<ICommand>().To<CreateGoalCommand>().Named("creategoal");
            this.Bind<ICommand>().To<ShowUserCommand>().Named("showuser");



        }
    }
}
