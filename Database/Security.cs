using Crypt = BCrypt.Net.BCrypt;

namespace Database
{
    public class Security
    {
        public static string Encrypt(string input)
        {
            return Crypt.EnhancedHashPassword(input);
        }

        public static bool Verify(string input, string hash)
        {
            return Crypt.EnhancedVerify(input, hash);
        }
    }
}
