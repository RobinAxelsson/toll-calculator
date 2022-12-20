﻿using System.Diagnostics.CodeAnalysis;

namespace toll_calculator.exceptions;

[Serializable]
[ExcludeFromCodeCoverage]
public abstract class TollCalculatorBaseException : Exception
{
    public abstract string Reason { get; }
    protected TollCalculatorBaseException() { }
    protected TollCalculatorBaseException(string message) : base(message) { }
    protected TollCalculatorBaseException(string message, Exception inner) : base(message, inner) { }
    protected TollCalculatorBaseException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
