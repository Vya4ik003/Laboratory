namespace Math.Tests
{
    internal class NumberService
    {
        MonomialGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new MonomialGenerator();
        }

        [Test]
        public void ReadNumberTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                (int, char, int) monomial = generator.GenerateMonomial();

                EqualsNumber(monomial.Item1, monomial.Item2, monomial.Item3);
            }
        }

        private void EqualsNumber(int coeff, char var, int power)
        {
            Monomial monomial = new Monomial(var, coeff, power);
            NumberReader reader = new NumberReader(monomial.ToString());
            Number result = reader.Read();

            Assert.That(monomial.Coefficient.Value, Is.EqualTo(result.Value));
        }
    }
}
