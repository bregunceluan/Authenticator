using Authenticator.Core.SharedContext.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Core.AccountContext.ValueObjects;

public class Password : ValueObject
{
    private const string Valid = "abcdefghijklmnopqrstuvxzwyABCDEFGHIJKLMNOPQRSTUVXZWYK0123456789";
    private const string Special = "!@#$%¨&*();^{}[]~";
    public string Hash { get; }
    public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..10].ToLower();

    private static string Generate(int length = 16,bool includeSpecialCharachters = true, bool upperCase = false)
    {
        var chars = includeSpecialCharachters ? (Special + Valid) : Valid;
        var startRandom = upperCase ? 26 : 0;
        var index = 0;
        var res = new char[length];
        var rnd = new Random(); 

        while (index < length)
        {
            res[index++] = chars[rnd.Next(startRandom, chars.Length)];
        }
        return new string(res);
    }


    private static string Hashing(string password, short saltSize = 16, short keySize = 32, int iterations = 10000, char splitChar = '.' )
    {
        if(string.IsNullOrEmpty(password)) throw new Exception("Password should not be empty");

        password += Configuration.Secrets.PasswordSaltKey;

        using var algorithm = new Rfc2898DeriveBytes(password,saltSize,iterations,HashAlgorithmName.SHA256);

        var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{iterations}{splitChar}{salt}{splitChar}{key}";
    }

    private static bool Verify(string hash,string password,short keySize = 32, int iterations = 10000, char splitChar = '.')
    {
        password += Configuration.Secrets.PasswordSaltKey;

        var hashParts = hash.Split('.',3);
        if (hashParts.Length != 3) return false;

        var hashIterations = hashParts[0];
        var salt = Convert.FromBase64String(hashParts[1]);
        var key = Convert.FromBase64String(hashParts[2]);

        if (hashIterations != iterations.ToString()) return false;

        using var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
    
        var keyToChek = algorithm.GetBytes(keySize);

        return keyToChek.SequenceEqual(key);
    }

}
