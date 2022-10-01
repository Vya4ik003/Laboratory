namespace Math.Tests
{
    public class MonomialService
    {
        MonomialGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new MonomialGenerator();
        }

        [Test]
        public void ReadMonomialTest()
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
            MonomialReader reader = new MonomialReader(monomial.ToString());
            Monomial result = reader.Read();

            Assert.That(monomial.ToString(), Is.EqualTo(result.ToString()));
        }
    }
}