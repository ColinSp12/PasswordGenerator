using System;
using System.Linq;
using System.Security.Cryptography;

class RandomPassword
{
    public static void Main(string[] args)
    {
        for (int ctr = 0; ctr < 100; ctr++)
        {
            var bytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            var password = string.Concat(bytes.Select(b => b.ToString("X2")));
            Console.WriteLine(password.Substring(0, 16)  + " : " + ctr);
        }
        Console.ReadLine();
    }
}