using System.Diagnostics;

namespace Bolt.Monad
{
    public static class MayBeStringExtensions
    {
        public static MayBe<string> Empty(this MayBe<string> source)
        {
            return source.When(value => string.IsNullOrWhiteSpace(value));
        }

        public static MayBe<string> WhenEmpty(this MayBe<string> source)
        {
            return source.When(value => string.IsNullOrWhiteSpace(value));
        }

        public static MayBe<string> NotEmpty(this MayBe<string> source)
        {
            return source.When(value => !string.IsNullOrWhiteSpace(value));
        }

        public static MayBe<string> WhenNotEmpty(this MayBe<string> source)
        {
            return source.When(value => !string.IsNullOrWhiteSpace(value));
        }

        [DebuggerStepThrough]
        public static MayBe<string> OtherwiseDefault(this MayBe<string> source)
        {
            return source.Otherwise(string.Empty);
        }
    }
}