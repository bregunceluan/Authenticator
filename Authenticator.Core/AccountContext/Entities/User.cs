using Authenticator.Core.AccountContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Core.AccountContext.Entities;

public class User
{
    public string Name { get; set; }
    public Email Email { get; private set; }
}


