using System.Collections.Generic;
using System.Linq;

namespace Math.Operands
{
    public class Polynomial
    {
        public List<Monomial> Monomials { get; set; }

        public Polynomial(params Monomial[] monomials)
        {
            Monomials = monomials.ToList();
        }

        public Polynomial(List<Monomial> monomials)
        {
            Monomials = monomials;
        }

        public Polynomial Simplify()
        {
            List<Monomial> monomials = new List<Monomial>();

            foreach (Monomial mon in Monomials)
            {
                if (monomials.Where(_ => _.Variable == mon.Variable).Count() == 0)
                {
                    List<Monomial> sameMonomials = Monomials.Where(_ => _.Variable == mon.Variable).ToList();
                    Number newCoeff = new Number(sameMonomials.Sum(_ => _.Coefficient.Value));
                    Monomial newMonomial = new Monomial(mon.Variable, newCoeff);
                    monomials.Add(newMonomial);
                }
            }



            Polynomial polynomial = new Polynomial(monomials);
            return polynomial;
        }

        public override string ToString()
        {
            string result = "";

            Monomials.ForEach(_ => result += _);

            return result;
        }

        #region Operators

        public static Polynomial operator +(Polynomial leftOperand, Polynomial rightOperand)
        {
            Polynomial result = new Polynomial();
            leftOperand.Monomials.ForEach(_ => result.Monomials.Add(_));
            rightOperand.Monomials.ForEach(_ => result.Monomials.Add(_));
            return result;
        }

        public static Polynomial operator -(Polynomial leftOperand, Polynomial rightOperand)
        {
            Polynomial result = new Polynomial();
            leftOperand.Monomials.ForEach(_ => result.Monomials.Add(_));
            rightOperand.Monomials.ForEach(_ => result.Monomials.Add(-_));
            return result;
        }

        #endregion
    }
}
