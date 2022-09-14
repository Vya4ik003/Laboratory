
namespace Math
{
    /// <summary>
    /// Целое число
    /// </summary>
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
    }
}
