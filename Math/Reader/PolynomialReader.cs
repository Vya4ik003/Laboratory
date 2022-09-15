using Math.Operands;
using System.Linq;

namespace Math.Reader
{
    public class PolynomialReader
    {
        private readonly string _input;
        private int _index = 0;

        public PolynomialReader(string input)
        {
            _input = input;
        }

        public bool IsEnd()
        {
            return _index >= _input.Length - 1;
        }

        private Monomial ReadMonomial()
        {
            string line = "";

            while (!IsEnd() && _input[_index + 1] != '+' && _input[_index + 1] != '-')
            {
                line += _input[_index++];
            }
            line += _input[_index++];

            char varName = line.Where(_ => char.IsLetter(_)).ToArray().FirstOrDefault();
            string coeffString = "";
            line.Where(_ => char.IsDigit(_) || _ == '+' || _ == '-').ToList().ForEach(_ => coeffString += _);
            int coeff = int.Parse(coeffString);

            Monomial result = new Monomial(varName, coeff);

            return result;
        }

        public Polynomial Read()
        {
            Polynomial polynomial = new Polynomial();

            while (!IsEnd())
            {
                Monomial monomial = ReadMonomial();
                polynomial.Monomials.Add(monomial);
            }

            return polynomial;
        }
    }
}
