using NUnit.Framework.Internal;

namespace Math.Tests
{
    internal class VariableService
    {
        MonomialGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new MonomialGenerator();
        }

        [Test]
        public void ReadVariableTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                (int, char, int) monomial = generator.GenerateMonomial();

                EqualsVariable(monomial.Item1, monomial.Item2, monomial.Item3);
            }
        }

        private void EqualsVariable(int coeff, char var, int power)
        {
            Monomial monomial = new Monomial(var, coeff, power);
            VariableReader reader = new VariableReader(monomial.ToString());
            Variable result = reader.Read();

            Assert.That(result.Symbol, Is.EqualTo(monomial.Variable.Symbol));
        }
    }
}
