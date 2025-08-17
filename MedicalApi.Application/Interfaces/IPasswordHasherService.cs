namespace MedicalApi.Application.Interfaces
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
    }
}