using Authenticator.Core.AccountContext.Entities;
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
                var senha = "minh@Senha";
                var user = new User("luanbregunce@gmail.com", senha);
                var testeSenha = user.Password.Challenge("teste senha");
                var testeSenha2 = user.Password.Challenge("minh@senha");



            }
            catch (VerificationCodeException ex)
            {
            }
        }
    }
}