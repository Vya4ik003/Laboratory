using System;
using System.Collections.Generic;
using System.Text;

namespace Math.Tests
{
    internal class MonomialGenerator
    {
        private char[] _varNames = new[]
        { 'a', 'b', 'c', 'd', 'x', 'y', 'z', '\0' };

        public (int, char, int) GenerateMonomial()
        {
            Random randomGenerator = new Random();

            int coeff = randomGenerator.Next(-100, 100);
            int index = randomGenerator.Next(_varNames.Length);
            char varName = _varNames[index];
            int power = randomGenerator.Next(100);

            return (coeff, varName, power);
        }
    }
}
