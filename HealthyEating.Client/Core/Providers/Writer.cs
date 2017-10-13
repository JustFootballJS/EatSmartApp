using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Providers
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
