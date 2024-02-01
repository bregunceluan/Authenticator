using Authenticator.Core.AccountContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Core.AccountContext.Entities;

public class User
{
    public string Name { get; set; } = string.Empty!;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    protected User() { }
    public User(string email,string? password = null)
    {
        Email = email;
        Password = new Password(password);
    }

    public void UpdatePassword(string plainTextPassword, string code)
    {
        if(!string.Equals(code.Trim(),this.Password.ResetCode,StringComparison.CurrentCultureIgnoreCase)) 
        {
            throw new Exception("Invalid code");
        }
        Password = new Password(plainTextPassword);
    }


    public void UpdateEmail(string newEmail)
    {
        Email = newEmail;
    }

    public void ChangePassword(string plainTextWord)
    {
        Password = new Password(plainTextWord);
    }
}


