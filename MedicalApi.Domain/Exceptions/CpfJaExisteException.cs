namespace MedicalApi.Domain.Exceptions;

public class CpfJaExisteException : BaseException
{
    public CpfJaExisteException(string cpf) : base($"CPF '{cpf}' já está cadastrado")
    {
    }
    
    public override int StatusCode => 409; // Conflict
}
