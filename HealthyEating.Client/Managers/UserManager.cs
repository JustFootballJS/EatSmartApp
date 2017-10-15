using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Linq;
using HealthyEating.Client.Models;
using Bytes2you.Validation;

namespace HealthyEating.Client.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly IDatabase database;
        private readonly IModelFactory modelFactory;

        public UserManager(IPasswordHasher passwordHasher, IDatabase database, IModelFactory modelFactory)
        {
            Guard.WhenArgument(passwordHasher, "passwordHasher").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();
            Guard.WhenArgument(modelFactory, "modelFactory").IsNull().Throw();

            this.passwordHasher = passwordHasher;
            this.database = database;
            this.modelFactory = modelFactory;
        }
        public User LoggedUser { get; set; }

        public string SignUp(string username, string password)
        {
            Guard.WhenArgument(username, "username").IsEmpty().IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(password, "password").IsEmpty().IsNullOrWhiteSpace().Throw();

            if (this.database.Users.SingleOrDefault(x => x.Username == username) != null)
            {
                throw new ArgumentException("Username has been already taken");
            }

            var hashedPassword = this.passwordHasher.Hash(password);

            var user = modelFactory.CreateUser(username, hashedPassword);
            database.Users.Add(user);

            return $"User {username} was created successfully";
        }

        public string LogIn(string username, string password)
        {
            Guard.WhenArgument(username, "username").IsEmpty().IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(password, "password").IsEmpty().IsNullOrWhiteSpace().Throw();

            var user = database.Users.Single(x => x.Username == username);

            if (user != null && passwordHasher.Verify(password, user.Password) && user.IsDeleted == false)
            {
                this.LoggedUser = user;

                return $"Hi, {user.Username}!";
            }
            else
            {
                throw new ArgumentException("Wrong username or password");
            }
        }

        public string Logout()
        {
            this.LoggedUser = null;
            return "Log out successful";
        }

        public string RecoverAccount(string username, string password, string answer)
        {
            Guard.WhenArgument(username, "username").IsEmpty().IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(password, "password").IsEmpty().IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(answer, "answer").IsEmpty().IsNullOrWhiteSpace().Throw();

            var user = this.database.Users.Single(x => x.Username == username);
            if (user == null)
            {
                throw new Exception("Wrong username or password");
            }
            else if (user.IsDeleted == false)
            {
                throw new Exception("Sorry but this account is active");
            }
            else if (this.passwordHasher.Verify(password, user.Password) && (answer == "yes" || answer == "y"))
            {
                user.IsDeleted = false;
                this.LoggedUser = user;
                return "Account successfully recovered!";
            }
            else 
            {
                throw new Exception("You cannot proceed without agreeing");
            }
           
        }

        public string DeleteAccount(string answer)
        {
            if (answer == "yes" || answer == "y")
            {
                this.LoggedUser.IsDeleted = true;
                this.LoggedUser = null;

                return "Your account has been deleted";
            }
            else
            {
                return "Your account has not been deleted";
            }
        }

        public string UserAsString(IDatabase database, string username)
        {
            Guard.WhenArgument(username, "username").IsEmpty().IsNullOrWhiteSpace().Throw();

            var user = database.Users.Single(x => x.Username == username);
            return string.Concat(
                $"Username: {user.Username}",
                Environment.NewLine,
                $"Recipes: ",
                Environment.NewLine,
                string.Join(Environment.NewLine, user.Recipes),
                Environment.NewLine,
                $"Meal History: ",
                Environment.NewLine,
                string.Join(Environment.NewLine, user.Logs),
                Environment.NewLine,
                $"Current weight: {user.CurrentWeight}",
                Environment.NewLine
                );
        }
    }
}
