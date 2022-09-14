using System.Collections.Generic;
using System.Linq;

namespace Math.Reader
{
    public class Expression
    {
        private string _expression;

        public Expression (string expression)
        {
            _expression = expression;
        }
        
        public List<Number> GetNumbers()
        {
            List<Number> result = new List<Number>();

            result = _expression.Split('+', '-', '/', '*').ToList().Select(_ => new Number(_)).ToList();

            return result;
        }
    }
}
