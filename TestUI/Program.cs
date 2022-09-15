using System;
using System.Collections.Generic;
using Math.Operands;

namespace TestUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Monomial> monomials1 = new List<Monomial>
            {
                new Monomial('a', -5),
                new Monomial('b', 1),
                new Monomial('x', 18),
                new Monomial('a', 6),
                new Monomial('b', -2),
                new Monomial('x', 10),
            };

            List<Monomial> monomials2 = new List<Monomial>
            {
                new Monomial('a', 3),
                new Monomial('b', 8),
                new Monomial('x', -2),
                new Monomial('a', 9),
                new Monomial('b', 0),
                new Monomial('x', -13),
            };

            Polynomial polynomial1 = new Polynomial(monomials1);
            Polynomial polynomial2= new Polynomial(monomials2);
            Polynomial polynomial3 = polynomial1 + polynomial2;
            Polynomial polynomial4 = polynomial1 - polynomial2;

            Write(polynomial1);
            Write(polynomial2);

            Console.WriteLine("Summ:");
            Write(polynomial3);

            Console.WriteLine("Substraction:");
            Write(polynomial4);
        }

        private static void Write(Polynomial polynomial)
        {
            Console.WriteLine("Polynomial:");
            Console.WriteLine(polynomial.ToString());
            Console.WriteLine("Simplified polynomial:");
            Console.WriteLine(polynomial.Simplify().ToString());
            Console.WriteLine();
        }
    }
}
