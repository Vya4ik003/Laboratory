using Math.Operands;
using System.Linq;

namespace Math.Reader
{
    public class NumberReader : Reader<Number>
    {
        protected override string Input { get; }
        protected int Index { get; set; }

        public NumberReader(string input)
        {
            Input = input;
        }

        public override bool IsEnd()
        {
            //bool eol = Index >= Input.Length - 1;
            bool isVar = (!char.IsDigit(Input[Index]) && Input[Index] != '^' && Input[Index] != '-' && Input[Index] != '+')
                || Input[Index] == '\0';

            return isVar;
        }

        public override Number Read()
        {
            string line = "";

            while (!IsEnd())
            {
                line += Input[Index++];

                if (Index >= Input.Length)
                    break;
            }

            if (line == "")
                line = "1";
            if (line == "-")
                line = "-1";

            Number result = new Number(line);
            Index = 0;

            return result;
        }
    }
}
