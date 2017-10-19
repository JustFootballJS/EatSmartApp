using HealthyEating.Client.Models;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IXMLProvider
    {
        IEnumerable<Ingredient> ReadUserFromXML(string fileName);
    }
}
