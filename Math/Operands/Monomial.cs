
namespace Math.Operands
{
    public class Monomial
    {
        internal Variable Variable { get; set; }
        internal Number Coefficient { get; set; }
        internal Number Power { get; set; }

        public Monomial(char var, int coeff)
        {
            Variable = new Variable(var);
            Coefficient = new Number(coeff);
            Power = new Number(1);
        }

        public Monomial(char var, int coeff, int power)
        {
            Variable = new Variable(var);
            Coefficient = new Number(coeff);
            Power = new Number(power);
        }

        internal Monomial(Variable var, Number coeff)
        {
            Variable = var;
            Coefficient = coeff;
            Power = new Number(1);
        }

        internal Monomial(Variable var, Number coeff, Number power)
        {
            Variable = var;
            Coefficient = coeff;
            Power = power;
        }

        public bool IsSame(Monomial monomial)
        {
            return Variable == monomial.Variable &&
                Power == monomial.Power;
        }

        #region overrided methods

        public override string ToString()
        {
            return Coefficient.ToString() +
                (Power == 0 ? "1" : Variable.ToString()) +
                (Power == 1 ? "" : "^" +
                (Power > 0 ? Power.ToString().Trim('+') : Power.ToString()));
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

        public static Polynomial operator +(Monomial leftOperand, Monomial rightOperand)
        {
            if (leftOperand.Variable.Symbol == rightOperand.Variable.Symbol &&
                leftOperand.Power == rightOperand.Power)
            {
                Number newCoeff = leftOperand.Coefficient + rightOperand.Coefficient;
                Number power = leftOperand.Power;
                Monomial result = new Monomial(leftOperand.Variable, newCoeff, power);
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
