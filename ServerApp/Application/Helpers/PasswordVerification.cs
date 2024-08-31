using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Helpers
{
    public static class PasswordVerification
    {
        public static bool Check(string password, string storedHash)
        {
            var passwordHasher = new PasswordHasher<User>();
            var verificationResult = passwordHasher.VerifyHashedPassword(null, storedHash, password);

            return verificationResult == PasswordVerificationResult.Success;
        }
    }
}
