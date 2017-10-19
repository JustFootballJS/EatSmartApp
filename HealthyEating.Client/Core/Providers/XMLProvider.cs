using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace HealthyEating.Client.Core.Providers
{
    public class XMLProvider : IXMLProvider
    {
        public IEnumerable<Ingredient> ReadUserFromXML(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();

            var document = XElement.Load($"../../IngredientsForSeeding/{fileName}");
            var foods = document.Elements("element").Select(x =>
             {
                 return new Ingredient()
                 {
                     Name = x.Element("Name").Value,
                     KCAL = decimal.Parse(x.Element("Kcal").Value),
                     Protein = decimal.Parse(x.Element("Protein").Value),
                     Fat = decimal.Parse(x.Element("Fat").Value),
                     Carbohydrate = decimal.Parse(x.Element("Carbohydrate").Value),
                     Fibre = decimal.Parse(x.Element("Fibre").Value)
                 };
             });

            return foods;
        }
    }
}
