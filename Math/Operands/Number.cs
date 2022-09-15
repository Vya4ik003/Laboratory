
namespace Math.Operands
{
    internal class Number
    {
        public int Value { get; set; }

        public Number(int value)
        {
            Value = value;
        }

        public Number(string value)
        {
            Value = int.Parse(value);
        }

        public override string ToString()
        {
            return Value >= 0 ? "+" + Value : "" + Value;
        }

        #region Operators

        public static Number operator +(Number num1, Number num2) => 
            new Number(num1.Value + num2.Value);

        public static Number operator -(Number num1, Number num2) => 
            new Number(num1.Value - num2.Value);

        public static Number operator -(Number num) =>
            new Number(-num.Value);

        #endregion
    }
}
