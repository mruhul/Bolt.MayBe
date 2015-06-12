using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bolt.Monad
{
    public static class MayBeEnumerableExtensions
    {
        [DebuggerStepThrough]
        public static MayBe<IEnumerable<T>> ForEach<T>(this MayBe<IEnumerable<T>> source, Action<T> action)
        {
            if (!source.HasValue) return source;
            
            foreach (var item in source.Value)
            {
                action.Invoke(item);
            }

            return source;
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<T>> IfNotEmpty<T>(this MayBe<IEnumerable<T>> source)
        {
            return WhenNotEmpty(source);
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<T>> WhenNotEmpty<T>(this MayBe<IEnumerable<T>> source)
        {
            return WhenHasItem(source);
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<T>> WhenHasItem<T>(this MayBe<IEnumerable<T>> source)
        {
            if (!source.HasValue) return source;

            return source.Value.Any() ? source : MayBe<IEnumerable<T>>.None;
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<TOutput>> Select<TInput, TOutput>(this MayBe<IEnumerable<TInput>> source,
            Func<TInput, TOutput> selector)
        {
            return !source.HasValue
                ? MayBe<IEnumerable<TOutput>>.None
                : source.Value.Select(selector.Invoke).MayBeNotNull();
        }

        [DebuggerStepThrough]
        public static MayBe<T> FirstOrDefault<T>(this MayBe<IEnumerable<T>> source)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : source.Value.FirstOrDefault().MayBeNotNull();
        }

        [DebuggerStepThrough]
        public static MayBe<T> FirstOrDefault<T>(this MayBe<IEnumerable<T>> source, Func<T,bool> predicate)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : source.Value.FirstOrDefault(predicate).MayBeNotNull();
        }

        [DebuggerStepThrough]
        public static MayBe<T> SingleOrDefault<T>(this MayBe<IEnumerable<T>> source, Func<T,bool> predicate)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : source.Value.SingleOrDefault(predicate).MayBeNotNull();
        }

        [DebuggerStepThrough]
        public static MayBe<T> SingleOrDefault<T>(this MayBe<IEnumerable<T>> source)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : source.Value.SingleOrDefault().MayBeNotNull();
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<TOutput>> SelectMany<TInput, TOutput>(this MayBe<IEnumerable<TInput>> source,
            Func<TInput, IEnumerable<TOutput>> selector)
        {
            if (!source.HasValue) return MayBe<IEnumerable<TOutput>>.None;

            var result = from s in source.Value
                         from item in selector.Invoke(s)
                         select item;

            return result.MayBeNotNull();
        } 
    }
}