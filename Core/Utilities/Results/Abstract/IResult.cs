using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Abstract.Results
{
    // Temel Void'ler için
    public interface IResult
    {
        bool Success { get;  }
        string Message { get; }
    }
}
