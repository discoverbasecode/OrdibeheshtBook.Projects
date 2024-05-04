namespace Framework.Core.Domain.Exceptions;

public class InvalidDomainDataException : BaseDomainException
{
    public InvalidDomainDataException() { }
    public InvalidDomainDataException(string message) : base(message) { }

}