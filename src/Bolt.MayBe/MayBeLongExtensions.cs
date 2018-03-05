namespace Bolt.Monad
{
    public static class MayBeLongExtensions
    {
        public static MayBe<long> GreaterThanZero(this MayBe<long> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<long> WhenGreaterThanZero(this MayBe<long> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<long> GreaterThan(this MayBe<long> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<long> WhenGreaterThan(this MayBe<long> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<long> GreaterThanOrEqual(this MayBe<long> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<long> WhenGreaterThanOrEqual(this MayBe<long> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<long> LessThan(this MayBe<long> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<long> WhenLessThan(this MayBe<long> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<long> LessThanOrEqual(this MayBe<long> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<long> WhenLessThanOrEqual(this MayBe<long> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<long> InRange(this MayBe<long> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }

        public static MayBe<long> WhenInRange(this MayBe<long> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }

        public static MayBe<long?> OtherwiseDefault(this MayBe<long?> source)
        {
            return source.Otherwise(0);
        }
    }
}