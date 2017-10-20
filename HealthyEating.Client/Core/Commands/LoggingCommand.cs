using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands
{
    public class LoggingCommand : Command, ICommand
    {
        private readonly IDatabase database;
        private readonly IUserManager userManager;

        public LoggingCommand(IReader reader, IWriter writer, IDatabase database, IUserManager userManager) : base(reader, writer)
        {
            this.database = database;
            this.userManager = userManager;
        }

        public override string Execute()
        {
            List<User> users = new List<User>();
            users = this.database.Users.ToList();

            System.IO.FileStream fs = new FileStream(@"..\..\Login Log.pdf", FileMode.Append);

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            // Add meta information to the document
            document.AddAuthor("Team_9");
            document.AddKeywords("EatHealthy Users");
            document.AddSubject("Document subject - Keepig a log users");
            document.AddTitle("Users");

            document.Open();
            foreach (User u in users)
            {
                document.Add(new Paragraph(string.Format($"Username: {u.Username}     ###     Number of Recipes: {u.Recipes.Count()}     ###     Current Weight: {u.CurrentWeight}")));
            }
            document.Close();
            writer.Close();
            fs.Close();

            return "Logging Complete!";
        }
    }
}