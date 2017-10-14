using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Models;
using System;
using System.IO;
using System.Xml;

namespace HealthyEating.Client.Core.Providers
{
    public class XMLProvider : IXMLProvider
    {
        public User ReadUserFromXML(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"../../UsersInXML/{fileName}");
            XmlNodeList username = xmlDoc.GetElementsByTagName("Username");
            XmlNodeList password = xmlDoc.GetElementsByTagName("Password");
            XmlNodeList id = xmlDoc.GetElementsByTagName("Id");
            XmlNodeList currweight = xmlDoc.GetElementsByTagName("CurrentWeight");

            return new User()
            {
                Username = username[0].InnerText,
                Password = password[0].InnerText,
                CurrentWeight = double.Parse(currweight[0].InnerText),
                Id = int.Parse(id[0].InnerText)
            };
        }
    }
}
