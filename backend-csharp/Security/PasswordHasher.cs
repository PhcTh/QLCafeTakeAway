using System.Security.Cryptography;

namespace backend_csharp.Security;

public static class PasswordHasher
{
    private const string Prefix = "PB1";
    private const int Iterations = 120_000;
    private const int SaltSize = 12;
    private const int HashSize = 24;

    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize);

        return $"{Prefix}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string password, string storedValue)
    {
        if (string.IsNullOrWhiteSpace(storedValue))
        {
            return false;
        }

        var parts = storedValue.Split('$');
        if (parts.Length != 3 || parts[0] != Prefix)
        {
            return SlowEquals(
                System.Text.Encoding.UTF8.GetBytes(password),
                System.Text.Encoding.UTF8.GetBytes(storedValue));
        }

        try
        {
            var salt = Convert.FromBase64String(parts[1]);
            var expected = Convert.FromBase64String(parts[2]);
            var actual = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                expected.Length);

            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool NeedsRehash(string storedValue)
    {
        return !storedValue.StartsWith($"{Prefix}$", StringComparison.Ordinal);
    }

    private static bool SlowEquals(byte[] left, byte[] right)
    {
        var length = Math.Max(left.Length, right.Length);
        var diff = left.Length ^ right.Length;

        for (var i = 0; i < length; i++)
        {
            var l = i < left.Length ? left[i] : (byte)0;
            var r = i < right.Length ? right[i] : (byte)0;
            diff |= l ^ r;
        }

        return diff == 0;
    }
}
