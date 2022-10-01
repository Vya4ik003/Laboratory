
using System.Linq.Expressions;

namespace Math.Operands
{
    public class Variable
    {
        public char Symbol { get; set; }
        public Number Power { get; set; }

        public Variable(char symbol, int power = 0)
        {
            Symbol = symbol;
            Power = new Number(power);
        }

        #region overrided methods

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

        #endregion

        #region Operators

        public static bool operator !=(Variable leftOperand, Variable rightOperand) => leftOperand.Symbol != rightOperand.Symbol;
        public static bool operator ==(Variable leftOperand, Variable rightOperand) => leftOperand.Symbol == rightOperand.Symbol;

        #endregion
    }
}
