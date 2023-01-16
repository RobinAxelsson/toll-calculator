using System.Runtime.Serialization;

internal class TollCalculationException : Exception
{
    public TollCalculationException()
    {
    }

    public TollCalculationException(string? message) : base(message)
    {
    }

    public TollCalculationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected TollCalculationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}