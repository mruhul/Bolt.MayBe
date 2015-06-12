namespace Bolt.Monad
{
    public class MayBe<T>
    {
        public static readonly MayBe<T> None = new MayBe<T>();
        
        private MayBe()
        {
        }

        public MayBe(T value)
        {
            Value = value;
            HasValue = value != null;
        }

        public T Value { get; private set; }
        public bool HasValue { get; private set; }
        public bool IsNone { get { return !HasValue; } }

        public T ValueOrDefault(T defaultValue)
        {
            return HasValue ? Value : defaultValue; 
        }

        public static implicit operator MayBe<T>(T value)
        {
            return value == null ? None : new MayBe<T>(value);
        }

        public static implicit operator T(MayBe<T> maybe)
        {
            return maybe.Value;
        }
    } 
}