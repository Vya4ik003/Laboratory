using System.Collections.Generic;
using System.Linq;
using System;

namespace Math.Operands
{
    public class Polynomial
    {
        public List<Monomial> Monomials { get; set; }

        public Polynomial(params Monomial[] monomials)
        {
            Monomials = monomials.ToList();
            PrimarySimplify();
        }

        public Polynomial(List<Monomial> monomials)
        {
            Monomials = monomials;
            PrimarySimplify();
        }

        private void PrimarySimplify()
        {
            if (Monomials.Count > 1)
                Monomials.RemoveAll(_ => _.Coefficient.Value == 0);
        }

        public Monomial TryParse()
        {
            if (Monomials.Count == 1)
                return Monomials[0];
            else
            {
                Simplify();
                return Monomials[0];
            }

        }

        public Polynomial Simplify()
        {
            List<Monomial> monomials = new List<Monomial>();

            foreach (Monomial mon in Monomials)
            {
                if (monomials.Where(_ => mon.IsSame(_)).Count() == 0)
                {
                    List<Monomial> sameMonomials = Monomials.Where(_ => mon.IsSame(_)).ToList();
                    Polynomial pol = new Polynomial();

                    if (sameMonomials.Count == 1)
                        pol.Monomials.Add(mon);

                    for (int i = 0; i < sameMonomials.Count - 1; i+=2)
                    {
                        pol += sameMonomials[i] + sameMonomials[i + 1];
                    }

                    if (sameMonomials.Count % 2 != 0)
                        pol += sameMonomials.Last();

                    Monomial newMonomial = pol.TryParse();
                    monomials.Add(newMonomial);
                }
            }

            Polynomial polynomial = new Polynomial(monomials);
            return polynomial;
        }

        #region overrided methods

        public override string ToString()
        {
            string result = "";
            Monomials = Monomials.OrderByDescending(_ => _.Variable.Power.Value).ToList();
            Monomials.ForEach(_ => result += _.ToStringSimplified());
            result = result.Trim('+');

            return result;
        }

        #endregion

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

        public static Polynomial operator +(Polynomial leftOperand, Monomial rightOperand)
        {
            Polynomial result = new Polynomial();
            leftOperand.Monomials.ForEach(_ => result.Monomials.Add(_));
            result.Monomials.Add(rightOperand);
            return result;
        }

        #endregion
    }
}
