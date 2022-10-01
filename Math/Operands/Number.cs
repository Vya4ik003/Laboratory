
namespace Math.Operands
{
    public class Number
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

        #region overrided methods

        public override string ToString()
        {
            string res = Value >= 0 ? "+" + Value : "" + Value;
            //if (res == "+1")
            //    res = "";
            //if (res == "-1")
            //    res = "-";

            return res;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Operators

        public static Number operator +(Number leftOperand, Number rigthOperand) =>
            new Number(leftOperand.Value + rigthOperand.Value);

        public static Number operator -(Number leftOperand, Number rigthOperand) =>
            new Number(leftOperand.Value - rigthOperand.Value);

        public static Number operator -(Number operand) =>
            new Number(-operand.Value);

        public static bool operator ==(Number leftOperand, Number rightOperand) =>
            leftOperand.Value == rightOperand.Value;

        public static bool operator !=(Number leftOperand, Number rightOperand) =>
            leftOperand.Value != rightOperand.Value;

        public static bool operator ==(Number leftOperand, int rightOperand) =>
            leftOperand.Value == rightOperand;

        public static bool operator !=(Number leftOperand, int rightOperand) =>
            leftOperand.Value == rightOperand;

        public static bool operator >(Number leftOperand, int rightOperand) =>
            leftOperand.Value > rightOperand;

        public static bool operator >=(Number leftOperand, int rightOperand) =>
            leftOperand.Value >= rightOperand;

        public static bool operator <(Number leftOperand, int rightOperand) =>
            leftOperand.Value > rightOperand;

        public static bool operator <=(Number leftOperand, int rightOperand) =>
            leftOperand.Value <= rightOperand;

        #endregion
    }
}
