namespace Math.Tests
{
    internal class PowerService
    {
        MonomialGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new MonomialGenerator();
        }

        [Test]
        public void ReadPowerTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                (int, char, int) monomial = generator.GenerateMonomial();

                EqualsMonomial(monomial.Item1, monomial.Item2, monomial.Item3);
            }
        }

        private void EqualsMonomial(int coeff, char var, int power)
        {
            Monomial monomial = new Monomial(var, coeff, power);
            PowerReader reader = new PowerReader(monomial.ToString());
            Number result = reader.Read();

            Assert.That(monomial.Power.Value, Is.EqualTo(result.Value));
        }
    }
}
