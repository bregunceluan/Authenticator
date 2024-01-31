using Authenticator.Core.AccountContext.Exceptions;
using Authenticator.Core.SharedContext.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Authenticator.Core.AccountContext.ValueObjects;

public partial class Email
{
    public const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public Email(string address)
    {
        if(string.IsNullOrEmpty(address)) 
            throw new InvalidEmailException("Invalid Email");
        if (address?.Length < 5) 
            throw new InvalidEmailException("Email is too short");
        if(!EmailRegex().IsMatch(Address)) 
            throw new InvalidEmailException("Invalid Email");
        Address = address.Trim().ToLower();
    }

    public static implicit operator string(Email email) => email.ToString();
    public static implicit operator Email(string address) => new Email(address);
    public override string ToString() => Address;
    public string Address { get; }
    public string Hash => Address.ToBase64();

    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();

}

