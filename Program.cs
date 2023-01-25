using System;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
//Program that generates a random 16 bit password
//Colin Spetz
class RandomPassword
{
    public static void Main(string[] args)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        using (FileStream target = File.Create(@"c:\users\colin\source\repos\COMP 60\Week3Practice\data.txt"))
        {
            using (StreamWriter writer = new StreamWriter(target))
            {
                for (int ctr = 0; ctr < 1000; ctr++)
                {

                    var bytes = new byte[16];
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(bytes);
                    }
                    var password = string.Concat(bytes.Select(b => b.ToString("X2")));
                    Console.WriteLine(password.Substring(0, 16) + " : " + ctr);

                }
            }
        }
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalSeconds} secs");
        Console.WriteLine($"Execution Time: { watch.ElapsedTicks} ticks");

        Console.ReadLine();
    }
}