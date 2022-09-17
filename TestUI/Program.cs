using System;
using System.Collections.Generic;
using Math.Operands;
using Math.Reader;

namespace TestUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            PolynomialReader reader = new PolynomialReader(line);
            Polynomial polynomial = reader.Read();

            Console.WriteLine(polynomial);
            Console.WriteLine(polynomial.Simplify());
        }
    }
}
