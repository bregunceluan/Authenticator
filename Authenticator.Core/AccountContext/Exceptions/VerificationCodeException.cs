using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Core.AccountContext.Exceptions;
public class VerificationCodeException : Exception
{
    public VerificationCodeException(string? message) : base(message)
    {
    }
}

