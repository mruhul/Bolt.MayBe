using System;
using System.Diagnostics;

namespace Bolt.Monad
{
    public static class MayBeExtensions
    {
        public static MayBe<T> MayBe<T>(this T source)
        {
            return source;
        }
        
        public static MayBe<TInput> Process<TInput>(this MayBe<TInput> source, Action<TInput> action)
        {
            if (source.IsNone) return source;

            action.Invoke(source.Value);

            return source;
        }

        
        public static MayBe<TOutput> Map<TInput, TOutput>(this MayBe<TInput> source, Func<TInput, TOutput> func)
        {
            if (source.IsNone) return Monad.MayBe<TOutput>.None;

            return func.Invoke(source.Value);
        }

        
        public static MayBe<TInput> Otherwise<TInput>(this MayBe<TInput> source, Func<TInput> funcAlternative)
        {
            if (!source.IsNone) return source;

            return funcAlternative.Invoke();
        }
        
        public static MayBe<TInput> Otherwise<TInput>(this MayBe<TInput> source, Action<TInput> funcAlternative)
        {
            if (!source.IsNone) return source;

            funcAlternative.Invoke(source.Value);

            return source;
        }

        
        public static MayBe<TInput> Otherwise<TInput>(this MayBe<TInput> source, TInput alternativeValue)
        {
            if (!source.IsNone) return source;
            return alternativeValue;
        }

        
        public static MayBe<TInput> When<TInput>(this MayBe<TInput> source, Func<TInput, bool> func)
        {
            if (source.IsNone) return source;

            return func.Invoke(source.Value) 
                ? source 
                : Monad.MayBe<TInput>.None;
        }

        public static MayBe<TInput> Filter<TInput>(this MayBe<TInput> source, Func<TInput, bool> func)
        {
            return source.When(func);
        }


        public static MayBe<TInput> Unless<TInput>(this MayBe<TInput> source, Func<TInput, bool> func)
        {
            if (source.IsNone) return source;

            return !func.Invoke(source.Value)
                ? source
                : Monad.MayBe<TInput>.None;
        }
    }
}