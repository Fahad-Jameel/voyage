using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.Manager.Utils
{
    public class Utilities
    {
        public string ComputeHash(string input)
        {
            SHA256 hashingAlgo = SHA256.Create();
            byte[] bytes = hashingAlgo.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2")); // "x2" formats as two hex digits
            }

            return builder.ToString();
        }
    }
}
