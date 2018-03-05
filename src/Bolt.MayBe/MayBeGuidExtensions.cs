using System;
using System.Diagnostics;

namespace Bolt.Monad
{
    public static class MayBeGuidExtensions
    {
        public static MayBe<Guid> NotEmpty(this MayBe<Guid> source)
        {
            return source.When(value => value != Guid.Empty);
        }

        public static MayBe<Guid> WhenNotEmpty(this MayBe<Guid> source)
        {
            return source.When(value => value != Guid.Empty);
        }

        public static MayBe<Guid> Empty(this MayBe<Guid> source)
        {
            return source.When(value => value == Guid.Empty);
        }

        public static MayBe<Guid> WhenEmpty(this MayBe<Guid> source)
        {
            return source.When(value => value == Guid.Empty);
        }

        public static MayBe<Guid?> NotEmpty(this MayBe<Guid?> source)
        {
            return source.When(value => value != Guid.Empty);
        }

        public static MayBe<Guid?> WhenNotEmpty(this MayBe<Guid?> source)
        {
            return source.When(value => value != Guid.Empty);
        }

        public static MayBe<Guid?> Empty(this MayBe<Guid?> source)
        {
            return source.When(value => value == Guid.Empty);
        }

        public static MayBe<Guid?> WhenEmpty(this MayBe<Guid?> source)
        {
            return source.When(value => value == Guid.Empty);
        }

        [DebuggerStepThrough]
        public static MayBe<Guid?> OtherwiseEmpty(this MayBe<Guid?> source)
        {
            return source.Otherwise(Guid.Empty);
        }
    }
}