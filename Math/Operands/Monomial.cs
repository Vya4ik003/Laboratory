
namespace Math.Operands
{
    public class Monomial
    {
        internal Variable Variable { get; set; }
        internal Number Coefficient { get; set; }

        public Monomial(char var, int coeff)
        {
            Variable = new Variable(var);
            Coefficient = new Number(coeff);
        }

        internal Monomial(Variable var, Number coeff)
        {
            Variable = var;
            Coefficient = coeff;
        }

        public override string ToString()
        {
            return Coefficient.ToString() + Variable.ToString();
        }

        #region Operators

        public static Polynomial operator +(Monomial leftOperand, Monomial rightOperand)
        {
            if (leftOperand.Variable.Symbol == rightOperand.Variable.Symbol)
            {
                Number newCoeff = leftOperand.Coefficient + rightOperand.Coefficient;
                Monomial result = new Monomial(leftOperand.Variable.Symbol, newCoeff.Value);
                return new Polynomial(result);
            }
            else
            {
                return new Polynomial(leftOperand, rightOperand);
            }
        }

        public static Polynomial operator -(Monomial leftOperand, Monomial rightOperand)
        {
            if (leftOperand.Variable.Symbol == rightOperand.Variable.Symbol)
            {
                Number newCoeff = leftOperand.Coefficient - rightOperand.Coefficient;
                Monomial result = new Monomial(leftOperand.Variable.Symbol, newCoeff.Value);
                return new Polynomial(result);
            }
            else
            {
                return new Polynomial(leftOperand, rightOperand);
            }
        }

        public static Monomial operator -(Monomial operand) => 
            new Monomial(operand.Variable, -operand.Coefficient);

        #endregion
    }
}
