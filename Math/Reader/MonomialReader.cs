using Math.Operands;
using System.Linq;

namespace Math.Reader
{
    public class MonomialReader : Reader<Monomial>
    {
        protected override string Input { get; }
        protected int Index { get; set; }

        private NumberReader _numberReader;
        private VariableReader _variableReader;
        private PowerReader _powerReader;

        public MonomialReader(string input)
        {
            Input = input;
            Input.Append('\0');
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

            Variable var = new Variable('\0');
            if (line.Where(_ => char.IsLetter(_) || _ == '\0').Count() > 0)
            {
                _variableReader = new VariableReader(line);
                var = _variableReader.Read();
            }

            Number power = new Number(1);
            if (line.Where(_ => _ == '^').Count() > 0)
            {
                _powerReader = new PowerReader(line);
                power = _powerReader.Read();
            }
            var.Power = power;
            if (var.Symbol == '\0')
                var.Power = new Number(0);

            Monomial result = new Monomial(var, coeff, power);

            return result;
        }
    }
}
