using HealthyEating.Client.Models;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IJsonProvider
    {
        User ReadUserFromJSON(string fileName);
    }
}
