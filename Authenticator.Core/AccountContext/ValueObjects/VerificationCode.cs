using Authenticator.Core.AccountContext.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Core.AccountContext.ValueObjects;
public class VerificationCode
{
    public string Code { get; } = Guid.NewGuid().ToString("N")[..8];
    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
    public DateTime? VerifiedAt { get; private set; } = null;
    public bool IsActived => VerifiedAt != null && ExpiresAt == null;

    public void Verify(string code)
    {
        if (IsActived) throw new VerificationCodeException("This code is already verified");
        if (VerifiedAt < DateTime.UtcNow) throw new VerificationCodeException("This code is expired");
        if (string.Equals(code.Trim(),this.Code.Trim(),StringComparison.CurrentCulture)) throw new VerificationCodeException("The code typed is wrong");
        ExpiresAt = null;
        VerifiedAt =  DateTime.UtcNow;
    }

}


