using System;
using System.Linq;

namespace BankNumberGenerator
{   public interface IRandomGenerator
    {
        string GenerateNumber(int length);
    }
    public class RandomGenerator : IRandomGenerator
    {
        private Random random = new Random();

        public string GenerateNumber(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
