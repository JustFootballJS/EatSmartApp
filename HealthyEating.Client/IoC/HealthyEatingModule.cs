using HealthyEating.Client.Core;
using HealthyEating.Client.Core.Commands;
using HealthyEating.Client.Core.Commands.RecomendCommands;
using HealthyEating.Client.Core.Commands.UserCommands;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Core.Factories;
using HealthyEating.Client.Core.Providers;
using HealthyEating.Client.Data;
using HealthyEating.Client.Managers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.IoC
{
    public class HealthyEatingModule : NinjectModule
    {
            
        public override void Load()
        {
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IReader>().To<Reader>().InSingletonScope();
            this.Bind<IWriter>().To<Writer>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            
            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IModelFactory>().To<ModelFactory>();
            this.Bind<IFoodRecomender>().To<FoodRecommender>();
            this.Bind<IUserManager>().To<UserManager>();
            this.Bind<IDatabase>().To<HealthyEatingContext>();
            this.Bind<IPasswordHasher>().To<PasswordHasher>();

            this.Bind<ICommand>().To<CreateRecipeCommand>().Named("createrecipe");
            this.Bind<ICommand>().To<ListRecipesCommand>().Named("listrecipes");
            this.Bind<ICommand>().To<ChangeCurrentWeightCommand>().Named("changecurrentweight");
            this.Bind<ICommand>().To<DeleteAccountCommand>().Named("deleteaccount");
            this.Bind<ICommand>().To<LogInCommand>().Named("login");
            this.Bind<ICommand>().To<LogoutCommand>().Named("logout");
            this.Bind<ICommand>().To<RecoverAccountCommand>().Named("recovereaccount");
            this.Bind<ICommand>().To<SignUpCommand>().Named("signup");
            this.Bind<ICommand>().To<RecommendFullPortionsCommand>().Named("recommendfullportions");
            this.Bind<ICommand>().To<RecommendNotFullPortionsCommand>().Named("recommendnotfullportions");



        }
    }
}
