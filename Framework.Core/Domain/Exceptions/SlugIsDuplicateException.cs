namespace Framework.Core.Domain.Exceptions;

public class SlugIsDuplicateException(string message) : BaseDomainException(message)
{
    public SlugIsDuplicateException() : this("slug تکراری است") { }

}