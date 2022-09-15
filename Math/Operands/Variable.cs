
namespace Math.Operands
{
    internal class Variable
    {
        public char Symbol { get; set; }

        public Variable(char symbol)
        {
            Symbol = symbol;
        }

        public override string ToString()
        {
            return "" + Symbol;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region Operators

        public static bool operator !=(Variable leftOperand, Variable rightOperand) => leftOperand.Symbol != rightOperand.Symbol;
        public static bool operator ==(Variable leftOperand, Variable rightOperand) => leftOperand.Symbol == rightOperand.Symbol;

        #endregion
    }
}
