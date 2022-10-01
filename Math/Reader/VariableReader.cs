using Math.Operands;
using System.Linq;

namespace Math.Reader
{
    public class VariableReader : Reader<Variable>
    {
        protected override string Input { get; }
        protected int Index { get; set; }

        public VariableReader(string input)
        {
            Input = input;
        }

        public override bool IsEnd()
        {
            return Index >= Input.Length - 1;
        }

        public override Variable Read()
        {
            char varName = Input.Where(_ => char.IsLetter(_)).ToArray().FirstOrDefault();
            Variable var = new Variable(varName);

            return var;
        }
    }
}
