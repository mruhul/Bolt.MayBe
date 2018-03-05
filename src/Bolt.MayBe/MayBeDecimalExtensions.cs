namespace Bolt.Monad
{
    public static class MayBeDecimalExtensions
    {
        public static MayBe<decimal> GreaterThanZero(this MayBe<decimal> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<decimal> WhenGreaterThanZero(this MayBe<decimal> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<decimal> GreaterThan(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<decimal> WhenGreaterThan(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<decimal> GreaterThanOrEqual(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<decimal> WhenGreaterThanOrEqual(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<decimal> LessThan(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<decimal> WhenLessThan(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<decimal> LessThanOrEqual(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<decimal> WhenLessThanOrEqual(this MayBe<decimal> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<decimal> InRange(this MayBe<decimal> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }

        public static MayBe<decimal> WhenInRange(this MayBe<decimal> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }

        public static MayBe<decimal?> OtherwiseDefault(this MayBe<decimal?> source)
        {
            return source.Otherwise(0);
        }
    }
}