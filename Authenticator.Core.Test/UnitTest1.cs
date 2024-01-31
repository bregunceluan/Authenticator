using Authenticator.Core.AccountContext.Exceptions;
using Authenticator.Core.AccountContext.ValueObjects;

namespace Authenticator.Core.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            try
            {
                var code = new VerificationCode();
                code.Verify("2143123jll12");
            }
            catch (VerificationCodeException ex)
            {
            }
        }
    }
}