using System.Runtime.Serialization;

namespace Gym.Domain.Exceptions;

[Serializable]
public class DomainException: ApplicationException
{
    public DomainException(string message)
        : base(message) { }

    public DomainException(string message, Exception innerException)
        : base(message, innerException) { }

    public DomainException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}