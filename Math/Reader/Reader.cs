
namespace Math.Reader
{
    public abstract class Reader<T>
    {
        protected abstract string Input { get; }
        public abstract bool IsEnd();
        public abstract T Read();
    }
}
