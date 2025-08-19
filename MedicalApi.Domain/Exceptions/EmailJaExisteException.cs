namespace MedicalApi.Domain.Exceptions;

public class EmailJaExisteException : BaseException
{
    public EmailJaExisteException(string email) : base($"Email '{email}' já está cadastrado")
    {
    }
    
    public override int StatusCode => 409; // Conflict
}
