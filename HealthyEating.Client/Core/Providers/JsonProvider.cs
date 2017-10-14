using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HealthyEating.Client.Core.Contracts;

namespace HealthyEating.Client.Core.Providers
{
    public class JsonProvider :IJsonProvider
    {
        public User ReadUserFromJSON(string fileName)
        {
            User user;
            using (StreamReader reader = new StreamReader($"../../UsersInJSON/{fileName}"))
            {
                var wholeFile = reader.ReadToEnd();
                user = JsonConvert.DeserializeObject<User>(wholeFile);
            }
            return user;
        }
    }
}
