namespace HealthyEating.Client.Core.Contracts
{
    public interface IPasswordHasher
    {
        string Hash(string password, int iterations);

        string Hash(string password);

        bool IsHashSupported(string hashString);

        bool Verify(string enteredPassword, string userPassword);
    }
}
