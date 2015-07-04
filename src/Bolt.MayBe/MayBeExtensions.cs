using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Bolt.Monad
{
    public static class MayBeExtensions
    {
        [DebuggerStepThrough]
        public static MayBe<T> MayBe<T>(this T source)
        {
            return source == null ? Monad.MayBe<T>.None : new MayBe<T>(source);
        }

        [DebuggerStepThrough]
        public static MayBe<T> MayBeNotNull<T>(this T source)
        {
            return MayBe(source);
        }

        [DebuggerStepThrough]
        public static async Task<MayBe<T>> MayBe<T>(this Task<T> source)
        {
            var value = await source;
            return MayBe(value);
        }

        [DebuggerStepThrough]
        public static MayBe<TOutput> Cast<TInput,TOutput>(this MayBe<TInput> source) 
            where TInput : class 
            where TOutput : class
        {
            return source.HasValue
                ? (source.Value as TOutput).MayBe()
                : Monad.MayBe<TOutput>.None;
        }

        [DebuggerStepThrough]
        public static MayBe<TOutput> MayCast<TInput, TOutput>(this TInput source)
            where TInput : class
            where TOutput : class
        {
            return source != null
                ? (source as TOutput).MayBe()
                : Monad.MayBe<TOutput>.None;
        }

        [DebuggerStepThrough]
        public static Task<MayBe<T>> MayBeNotNull<T>(this Task<T> source)
        {
            return MayBe(source);
        }
        
        [DebuggerStepThrough]
        public static MayBe<TOutput> Get<TInput,TOutput>(this MayBe<TInput> source, Func<TInput,TOutput> fetch)
        {
            return Select(source, fetch);
        }

        [DebuggerStepThrough]
        public static MayBe<TOutput> Select<TInput, TOutput>(this MayBe<TInput> source, Func<TInput, TOutput> fetch)
        {
            return source.HasValue
                ? fetch.Invoke(source.Value).MayBeNotNull()
                : Monad.MayBe<TOutput>.None;
        }
        
        [DebuggerStepThrough]
        public static MayBe<T> Do<T>(this MayBe<T> source, Action<T> action)
        {
            if(source.HasValue) action.Invoke(source.Value);

            return source;
        }

        [DebuggerStepThrough]
        public static MayBe<T> When<T>(this MayBe<T> source, Func<T, bool> predict)
        {
            if (!source.HasValue) return source;

            return predict.Invoke(source.Value)
                ? source
                : Monad.MayBe<T>.None;
        }

        [DebuggerStepThrough]
        public static MayBe<T> NoneWhen<T>(this MayBe<T> source, Func<T, bool> predict)
        {
            if (!source.HasValue) return source;

            return !predict.Invoke(source.Value)
                ? source
                : Monad.MayBe<T>.None;
        }
        
        [DebuggerStepThrough]
        public static MayBe<T> If<T>(this MayBe<T> source, Func<T, bool> predict)
        {
            if (!source.HasValue) return source;

            return predict.Invoke(source.Value) 
                ? source 
                : Monad.MayBe<T>.None;
        }

        [DebuggerStepThrough]
        public static MayBe<T> IfNot<T>(this MayBe<T> source, Func<T, bool> predict)
        {
            if (!source.HasValue) return source;

            return !predict.Invoke(source.Value)
                ? source
                : Monad.MayBe<T>.None;
        }

        [DebuggerStepThrough]
        public static MayBe<T> Otherwise<T>(this MayBe<T> source, Action action)
        {
            if (!source.HasValue) action.Invoke();

            return source;
        }
        
        [DebuggerStepThrough]
        public static MayBe<T> Otherwise<T>(this MayBe<T> source, Func<T> func)
        {
            return !source.HasValue 
                    ? func.Invoke().MayBeNotNull() 
                    : source;
        }
    }
}