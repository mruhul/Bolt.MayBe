using System.Diagnostics;

namespace Bolt.Monad
{
    public static class MayBeStringExtensions
    {
        [DebuggerStepThrough]
        public static MayBe<string> IfNotEmpty(this MayBe<string> source)
        {
            return WhenNotEmpty(source);
        }

        [DebuggerStepThrough]
        public static MayBe<string> WhenNotEmpty(this MayBe<string> source)
        {
            return source.When(value => !string.IsNullOrWhiteSpace(value));
        }
        
        [DebuggerStepThrough]
        public static MayBe<string> MayBeNotEmpty(this string source)
        {
            return string.IsNullOrWhiteSpace(source)
                ? Monad.MayBe<string>.None
                : new MayBe<string>(source);
        }

        [DebuggerStepThrough]
        public static string ValueOrDefault(this MayBe<string> source)
        {
            return source.ValueOrDefault(string.Empty);
        }
    }
}