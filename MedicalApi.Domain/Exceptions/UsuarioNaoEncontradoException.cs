namespace MedicalApi.Domain.Exceptions;

public class UsuarioNaoEncontradoException : BaseException
{
    public UsuarioNaoEncontradoException(Guid id) : base($"Usuário com ID '{id}' não foi encontrado")
    {
    }
    
    public override int StatusCode => 404; // Not Found
}
