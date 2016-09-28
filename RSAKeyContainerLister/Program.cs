using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RSAKeyContainerLister
{
    /// <summary>
    /// Lists available RSA key containers used by IIS. See also: https://security.stackexchange.com/questions/1771/how-can-i-enumerate-all-the-saved-rsa-keys-in-the-microsoft-csp.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys\");
            var errors = new List<string>();

            foreach (var f in files)
            {
                // try catch is to avoid some ACL issues on certain files
                try
                {
                    var bytes = File.ReadAllBytes(f);
                    var containerName = Encoding.ASCII.GetString(bytes, 40, bytes[8] - 1);

                    Console.WriteLine(containerName);
                }
                catch (UnauthorizedAccessException e)
                {
                    errors.Add(e.Message);
                }
            }

            if (errors.Any())
            {
                Console.WriteLine("\n\nErrors:");

                foreach (var e in errors)
                {
                    Console.WriteLine(e);
                }
            }

            Console.Read();
        }
    }
}