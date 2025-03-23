namespace Task3.Exceptions;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }

    public OverfillException(string message)
        : base(message)
    {
    }

    public OverfillException(string message, Exception inner)
        : base(message, inner)
    {
    }
}