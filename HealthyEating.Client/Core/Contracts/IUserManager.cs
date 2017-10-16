using HealthyEating.Client.Data;
using HealthyEating.Client.Models;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IUserManager
    {
        string UserAsString(IDatabase database, string username);

        User LoggedUser { get; set; }

        string RecoverAccount(string username, string password, string answer);

        string LogIn(string username, string passwerd);

        string SignUp(string username, string password);

        string DeleteAccount(string answer);

        string Logout();
    }
}
