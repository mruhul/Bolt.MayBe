using System.Diagnostics;

namespace Bolt.Monad
{
    public static class MayBeIntExtensions
    {
        public static MayBe<int> GreaterThanZero(this MayBe<int> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<int> WhenGreaterThanZero(this MayBe<int> source)
        {
            return source.When(value => value > 0);
        }

        public static MayBe<int> GreaterThan(this MayBe<int> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<int> WhenGreaterThan(this MayBe<int> source, int minValue)
        {
            return source.When(value => value > minValue);
        }

        public static MayBe<int> GreaterThanOrEqual(this MayBe<int> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<int> WhenGreaterThanOrEqual(this MayBe<int> source, int minValue)
        {
            return source.When(value => value >= minValue);
        }

        public static MayBe<int> LessThan(this MayBe<int> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<int> WhenLessThan(this MayBe<int> source, int minValue)
        {
            return source.When(value => value < minValue);
        }

        public static MayBe<int> LessThanOrEqual(this MayBe<int> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<int> WhenLessThanOrEqual(this MayBe<int> source, int minValue)
        {
            return source.When(value => value <= minValue);
        }

        public static MayBe<int> InRange(this MayBe<int> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }

        public static MayBe<int> WhenInRange(this MayBe<int> source, int minValue, int maxValue)
        {
            return source.When(value => value >= minValue && value <= maxValue);
        }
        
        public static MayBe<int?> OtherwiseDefault(this MayBe<int?> source)
        {
            return source.Otherwise(0);
        }
    }
}