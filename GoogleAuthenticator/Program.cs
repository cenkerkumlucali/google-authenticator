using System;
using System.Collections.Generic;
using OtpNet;

namespace GoogleAuthenticator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string base32Secret = "L52AM3FD452MARQQQPT54N6XVAJK6JR7";
            var secret = Base32Encoding.ToBytes(base32Secret);

            var totp = new Totp(secret);

            var usedTimeSteps = new HashSet<long>();

            while (true)
            {
                Console.Write("Enter code: ");
                string inputCode = Console.ReadLine();
                bool valid = totp.VerifyTotp(inputCode, out long timeStepMatched,
                    VerificationWindow.RfcSpecifiedNetworkDelay);

                valid &= !usedTimeSteps.Contains(timeStepMatched);
                usedTimeSteps.Add(timeStepMatched);

                string validStr = valid ? "Valid" : "Invalid";
                var colour = valid ? ConsoleColor.Green : ConsoleColor.Red;
                Console.ForegroundColor = colour;
                Console.WriteLine(validStr);
                Console.ResetColor();
            }
        }
    }
}
