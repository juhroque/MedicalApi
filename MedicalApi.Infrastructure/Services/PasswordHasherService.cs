using MedicalApi.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MedicalApi.Infrastructure.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        public string Hash(string password)
        {
            using var sha256 = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
