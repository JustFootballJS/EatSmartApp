using HealthyEating.Client.Models;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IXMLProvider
    {
        User ReadUserFromXML(string fileName);
    }
}
