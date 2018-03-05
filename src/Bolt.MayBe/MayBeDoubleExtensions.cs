namespace Bolt.Monad
{
    public static class MayBeDoubleExtensions
    {
        public static MayBe<double> GreaterThanZero(this MayBe<double> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<double> WhenGreaterThanZero(this MayBe<double> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<double> GreaterThan(this MayBe<double> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<double> WhenGreaterThan(this MayBe<double> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<double> GreaterThanOrEqual(this MayBe<double> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<double> WhenGreaterThanOrEqual(this MayBe<double> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<double> LessThan(this MayBe<double> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<double> WhenLessThan(this MayBe<double> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<double> LessThanOrEqual(this MayBe<double> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<double> WhenLessThanOrEqual(this MayBe<double> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<double> InRange(this MayBe<double> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }

        public static MayBe<double> WhenInRange(this MayBe<double> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }

        public static MayBe<double?> OtherwiseDefault(this MayBe<double?> source)
        {
            return source.Otherwise(0);
        }
    }
}