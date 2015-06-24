using System;
using System.Diagnostics;

namespace Bolt.Monad
{
    public static class MayBeGuidExtensions
    {
        [DebuggerStepThrough]
        public static MayBe<Guid> MayBeNotEmpty(this Guid source)
        {
            return source == Guid.Empty 
                ? MayBe<Guid>.None 
                : new MayBe<Guid>(source, true);
        }

        [DebuggerStepThrough]
        public static MayBe<Guid> WhenNotEmpty(this MayBe<Guid> source)
        {
            return source.HasValue && source.Value == Guid.Empty 
                ? MayBe<Guid>.None 
                : source;
        }

        [DebuggerStepThrough]
        public static MayBe<Guid?> MayBeNotNullOrEmpty(this Guid? source)
        {
            return source.HasValue && source.Value != Guid.Empty
                ? new MayBe<Guid?>(source, true)
                : MayBe<Guid?>.None;
        }

        [DebuggerStepThrough]
        public static MayBe<Guid?> WhenNotNullOrEmpty(this MayBe<Guid?> source)
        {
            return source.HasValue && source.Value != Guid.Empty
                ? source
                : MayBe<Guid?>.None;
        }

        [DebuggerStepThrough]
        public static Guid ValueOrEmpty(this MayBe<Guid?> source)
        {
            return source.HasValue && source.Value.HasValue 
                    ? source.Value.Value 
                    : Guid.Empty;
        }
    }
}