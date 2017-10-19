using HealthyEating.Client.Core;
using HealthyEating.Client.Core.Commands;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Core.Factories;
using HealthyEating.Client.Core.Providers;
using HealthyEating.Client.Data;
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
            //this.Bind<ICommandParser>().To<CommandParser>();
            this.Bind<IReader>().To<Reader>();
            this.Bind<IWriter>().To<Writer>();
            this.Bind<IEngine>().To<Engine>();

            this.Bind<IDatabase>().To<InMemoryDB>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IModelFactory>().To<ModelFactory>();
            this.Bind<ICommand>().To<CreateRecipeCommand>().Named("createrecipe");
            this.Bind<ICommand>().To<ListRecipesCommand>().Named("listrecipes");
            
        }
    }
}
