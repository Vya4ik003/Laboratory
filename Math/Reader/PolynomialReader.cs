using Math.Operands;
using System.Linq;

namespace Math.Reader
{
    public class PolynomialReader : Reader<Polynomial>
    {
        protected override string Input { get; }
        private readonly MonomialReader _monomialReader;

        public PolynomialReader(string input)
        {
            string formattedInput = FormatInput(input);
            Input = formattedInput;
            _monomialReader = new MonomialReader(formattedInput);
        }

        private string FormatInput(string input)
        {
            string result = input.Replace(" ", "");

            return result;
        }

        public override bool IsEnd()
        {
            return _monomialReader.IsEnd();
        }

        public override Polynomial Read()
        {
            Polynomial polynomial = new Polynomial();

            while (!IsEnd())
            {
                Monomial monomial = _monomialReader.Read();
                polynomial.Monomials.Add(monomial);
            }

            return polynomial;
        }
    }
}
