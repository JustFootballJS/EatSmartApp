using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Linq;
using HealthyEating.Client.Models;

namespace HealthyEating.Client.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly IDatabase database;
        private readonly IModelFactory modelFactory;

        public UserManager(IPasswordHasher passwordHasher, IDatabase database, IModelFactory modelFactory)
        {
            this.passwordHasher = passwordHasher;
            this.database = database;
            this.modelFactory = modelFactory;
        }
        public User LoggedUser { get ; set ; }

        public string SignUp(string username, string password)
        {
            var hashedPassword = this.passwordHasher.Hash(password);

            var user = modelFactory.CreateUser(username, hashedPassword);
            database.Users.Add(user);

            return $"User {username} was created successfully";
        }

        public string LogIn(string username, string password)
        {
            var user = database.Users.Single(x => x.Username == username);
            if (passwordHasher.Verify(password, user.Password) && user.IsDeleted == false)
            {
                this.LoggedUser = user;

                return $"Hi, {user.Username}!";
            }
            else if (user.IsDeleted)
            {
                throw new Exception();
            }
            else
            {
                throw new Exception();
            }
        }

        public string RecoverAccount(string username, string password, string answer)
        {
            var user = this.database.Users.Single(x => x.Username == username);
            if (user.IsDeleted == false)
            {
                throw new Exception();
            }
            else if (this.passwordHasher.Verify(password, user.Password) && (answer == "yes" || answer == "y"))
            {
                user.IsDeleted = false;
                this.LoggedUser = user;
                return "Account successfully recovered!";
            }
            else if (answer != "y" && answer != "yes")
            {
                throw new Exception();
            }
            else
            {
                throw new Exception();
            }
        }

        public string UserAsString(IDatabase database, string username)
        {
            var user=database.Users.Single(x => x.Username == username);
            return string.Concat($"Username: {user.Username}",
                Environment.NewLine,
                $"Recipes: ",
                Environment.NewLine,
                string.Join(Environment.NewLine,user.Recipes),
                Environment.NewLine,
                $"Meal History: ",
                Environment.NewLine,
                string.Join(Environment.NewLine,user.Logs),
                Environment.NewLine,
                $"Current weight: {user.CurrentWeight}",
                Environment.NewLine
                );
        }
    }
}
