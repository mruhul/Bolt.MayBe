namespace Bolt.Monad
{
    public static class MayBeStringExtensions
    {
        public static MayBe<string> IfNotEmpty(this MayBe<string> source)
        {
            return WhenNotEmpty(source);
        }

        public static MayBe<string> WhenNotEmpty(this MayBe<string> source)
        {
            return source.When(value => !string.IsNullOrWhiteSpace(value));
        }
    }
}