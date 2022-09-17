using Math.Operands;
using System.Linq;

namespace Math.Reader
{
    internal class MonomialReader : Reader<Monomial>
    {
        protected override string Input { get; }
        protected int Index { get; set; }

        private NumberReader _numberReader;
        private VariableReader _variableReader;
        private PowerReader _powerReader;

        public MonomialReader(string input)
        {
            Input = input;
        }

        public override bool IsEnd()
        {
            return Index >= Input.Length - 1;
        }

        public override Monomial Read()
        {
            string line = "";

            while (!IsEnd() && Input[Index + 1] != '+' && Input[Index + 1] != '-')
            {
                line += Input[Index++];
            }
            line += Input[Index++];

            _numberReader = new NumberReader(line);
            Number coeff = _numberReader.Read();

            _variableReader = new VariableReader(line);
            Variable var = _variableReader.Read();

            _powerReader = new PowerReader(line);
            Number power = _powerReader.Read();

            Monomial result = new Monomial(var, coeff, power);

            return result;
        }
    }
}
