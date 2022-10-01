using Math.Operands;

namespace Math.Reader
{
    public class PowerReader : Reader<Number>
    {
        protected override string Input { get; }
        protected int Index { get; set; }

        public PowerReader(string input)
        {
            Input = input;
        }

        public override bool IsEnd()
        {
            return Index >= Input.Length - 1;
        }

        public override Number Read()
        {
            var parts = Input.Split("^");
            Number result = new Number(1);
            if (parts.Length > 1)
            {
                int power = (parts[1] != "") ? int.Parse(parts[1]) : 1;
                result.Value = power;
            }

            return result;
        }
    }
}
