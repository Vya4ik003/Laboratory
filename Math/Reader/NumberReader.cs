using Math.Operands;

namespace Math.Reader
{
    internal class NumberReader : Reader<Number>
    {
        protected override string Input { get; }
        protected int Index { get; set; }

        public NumberReader(string input)
        {
            Input = input;
        }

        public override bool IsEnd()
        {
            return Index >= Input.Length - 1;
        }

        public override Number Read()
        {
            string line = "";

            while ((char.IsDigit(Input[Index]) 
                || Input[Index] == '-' 
                || Input[Index] == '+' ) 
                && !IsEnd())
            {
                line += Input[Index++];
            }

            if (line == "")
                line = "1";

            Number result = new Number(line);
            Index = 0;

            return result;
        }
    }
}
