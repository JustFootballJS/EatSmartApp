using System.Collections.Generic;

namespace HealthyEating.Client.Core.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}