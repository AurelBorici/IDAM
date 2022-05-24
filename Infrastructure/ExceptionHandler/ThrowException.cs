using System;
using System.Globalization;

namespace Infrastructure.ExceptionHandler;

public class ThrowException : Exception
{
    public ThrowException() : base()
    {
    }
    public ThrowException(string message) : base(message)
    {
    }
    public ThrowException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}
