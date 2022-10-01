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
            ConsoleKey key = ConsoleKey.Z;

            while (key != ConsoleKey.Escape)
            {
                PolynomialReader reader = new PolynomialReader(line);
                Polynomial polynomial = reader.Read();
                Polynomial simplifiedPolynomial = polynomial.Simplify();
                Console.WriteLine(simplifiedPolynomial.ToString());

                line = Console.ReadLine();
                key = Console.ReadKey().Key;
            }
        }
    }
}
