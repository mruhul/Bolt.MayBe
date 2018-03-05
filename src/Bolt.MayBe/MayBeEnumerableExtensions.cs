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
        public static MayBe<IEnumerable<T>> OtherwiseDefault<T>(this MayBe<IEnumerable<T>> source)
        {
            return source.Otherwise(Enumerable.Empty<T>);
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<T>> WhenAny<T>(this MayBe<IEnumerable<T>> source)
        {
            return source.When(value => value.Any());
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<T>> WhenEmpty<T>(this MayBe<IEnumerable<T>> source)
        {
            return source.When(value => !value.Any());
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<TOutput>> Select<TInput, TOutput>(this MayBe<IEnumerable<TInput>> source,
            Func<TInput, TOutput> selector)
        {
            return source.Map(items => items.Select(selector.Invoke));
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<TOutput>> Select<TInput, TOutput>(this MayBe<TInput[]> source,
            Func<TInput, TOutput> selector)
        {
            return source.Map(items => items.Select(selector.Invoke));
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<TOutput>> Select<TInput, TOutput>(this MayBe<ICollection<TInput>> source,
            Func<TInput, TOutput> selector)
        {
            return source.Map(items => items.Select(selector.Invoke));
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<TOutput>> Select<TInput, TOutput>(this MayBe<IList<TInput>> source,
            Func<TInput, TOutput> selector)
        {
            return source.Map(items => items.Select(selector.Invoke));
        }
        
        [DebuggerStepThrough]
        public static MayBe<T> FirstOrDefault<T>(this MayBe<IEnumerable<T>> source)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : new MayBe<T>(source.Value.FirstOrDefault());
        }

        [DebuggerStepThrough]
        public static MayBe<T> FirstOrDefault<T>(this MayBe<IEnumerable<T>> source, Func<T,bool> predicate)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : new MayBe<T>(source.Value.FirstOrDefault());
        }

        [DebuggerStepThrough]
        public static MayBe<T> SingleOrDefault<T>(this MayBe<IEnumerable<T>> source, Func<T,bool> predicate)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : new MayBe<T>(source.Value.SingleOrDefault());
        }

        [DebuggerStepThrough]
        public static MayBe<T> SingleOrDefault<T>(this MayBe<IEnumerable<T>> source)
        {
            return !source.HasValue
                    ? MayBe<T>.None
                    : new MayBe<T>(source.Value.SingleOrDefault());
        }

        [DebuggerStepThrough]
        public static MayBe<IEnumerable<TOutput>> SelectMany<TInput, TOutput>(this MayBe<IEnumerable<TInput>> source,
            Func<TInput, IEnumerable<TOutput>> selector)
        {
            if (!source.HasValue) return MayBe<IEnumerable<TOutput>>.None;

            var result = from s in source.Value
                         from item in selector.Invoke(s)
                         select item;

            return new MayBe<IEnumerable<TOutput>>(result);
        } 
    }
}