namespace Bolt.Monad
{
    public class MayBe<T>
    {
        private readonly bool _hasValue = false;

        internal MayBe()
        {
        }

        internal MayBe(T value)
            : this(value, value != null)
        {
        }

        internal MayBe(T value, bool hasValue)
        {
            Value = value;
            _hasValue = hasValue;
        }

        public static MayBe<T> None => new MayBe<T>();

        public T Value { get; private set; }

        public bool HasValue => _hasValue;
        public bool IsNone => !_hasValue;
        
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