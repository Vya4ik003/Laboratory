using System;

namespace Math.Operands
{
    public class Monomial
    {
        public Variable Variable { get; set; }
        public Number Coefficient { get; set; }

        public Monomial(char var, int coeff)
        {
            Variable = new Variable(var, 1);
            Coefficient = new Number(coeff);
        }

        public Monomial(char var, int coeff, int power)
        {
            Variable = new Variable(var, power);
            Coefficient = new Number(coeff);
        }

        internal Monomial(Variable var, Number coeff)
        {
            Variable = var;
            Coefficient = coeff;
        }

        internal Monomial(Variable var, Number coeff, Number power)
        {
            Variable = var;
            Coefficient = coeff;
        }

        public bool IsSame(Monomial monomial)
        {
            return Variable == monomial.Variable &&
                Variable.Power == monomial.Variable.Power;
        }

        public string ToStringSimplified()
        {
            return (MathF.Abs(Coefficient.Value) == 1 ? (Coefficient < 0 ? "-" : "+") : Coefficient.ToString()) +
            (Variable.Power == 0 ? ""
            : Variable.ToString() + (Variable.Power == 1 ? "" : "^" +
            (Variable.Power >= 0 ? Variable.Power.ToString().Trim('+') : Variable.Power.ToString())));
        }

        #region overrided methods

        public override string ToString()
        {
            return Coefficient.ToString() + Variable.ToString() + '^' +
                (Variable.Power >= 0 ? Variable.Power.ToString().Trim('+') : Variable.Power.ToString());
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
                leftOperand.Variable.Power == rightOperand.Variable.Power)
            {
                Number newCoeff = leftOperand.Coefficient + rightOperand.Coefficient;
                Number power = leftOperand.Variable.Power;
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
