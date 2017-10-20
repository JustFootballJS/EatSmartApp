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
            this.LoggedUser = user;
           this. database.SaveChanges();
            return $"User {username} was created successfully";
        }

        public string LogIn(string username, string password)
        {
            Guard.WhenArgument(username, "username").IsEmpty().IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(password, "password").IsEmpty().IsNullOrWhiteSpace().Throw();

            if (this.LoggedUser != null)
            {
                throw new ArgumentException("You are currently logged in. Please logout first!");
            }

            User user = null;
            foreach (var item in database.Users)
            {
                if (item.Username == username)
                {
                    user = item;
                }
            }
                        

           
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
            if (this.LoggedUser == null)
            {
                throw new ArgumentException("You are not currently logged in. Please login to logout.");
            }
            this.LoggedUser = null;
            return "Log out successful";
        }

        public string RecoverAccount(string username, string password, string answer)
        {
            Guard.WhenArgument(username, "username").IsEmpty().IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(password, "password").IsEmpty().IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(answer, "answer").IsEmpty().IsNullOrWhiteSpace().Throw();

            var user = this.database.Users.SingleOrDefault(x => x.Username == username);
            if (user == null|| this.passwordHasher.Verify(password, user.Password)==false)
            {
                throw new ArgumentException("Wrong username or password");
            }
            else if (user.IsDeleted == false)
            {
                throw new ArgumentException("Sorry but this account is active");
            }           
            else if (answer == "yes" || answer == "y")
            {
                user.IsDeleted = false;
                this.LoggedUser = user;
                return "Account successfully recovered!";
            }
            else 
            {
                throw new ArgumentException("You cannot proceed without agreeing");
            }
           
        }

        public string DeleteAccount(string answer)
        {
            if (this.LoggedUser == null)
            {
                throw new ArgumentException("Please login first!");
            }
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

        public string ChangeCurrentWeight(double newWeight)
        {
            this.LoggedUser.CurrentWeight = newWeight;
            this.database.SaveChanges();

            return "Current weight was changed successfully";
        }

        public string UserAsString( string username)
        {
            Guard.WhenArgument(username, "username").IsEmpty().IsNullOrWhiteSpace().Throw();

            var user = this.database.Users.Single(x => x.Username == username);
            return string.Concat(
                $"Username: {user.Username}",
                Environment.NewLine,
                $"Recipes: ",
                Environment.NewLine,
                string.Join(Environment.NewLine, user.Recipes.Select(x=>x.Name)),
                Environment.NewLine,
                $"Meal History: ",
                Environment.NewLine,
                string.Join(Environment.NewLine, user.Meals),
                Environment.NewLine,
                $"Current weight: {user.CurrentWeight}",
                Environment.NewLine
                );
        }
    }
}
