using Authenticator.Core.SharedContext.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Core.AccountContext.ValueObjects;

public class Email
{
    public const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public string Address { get; }

    public string Hash => Address.ToBase64(); 

}

