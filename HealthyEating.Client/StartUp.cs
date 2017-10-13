

using HealthyEating.Client.Core;
using HealthyEating.Client.IoC;
using Ninject;

namespace HealthyEating.Client
{
    public class StartUp
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel(new HealthyEatingModule());
            var engine = kernel.Get<IEngine>();

            engine.Run(); 
        }
    }
}
