using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolt.Monad
{
    public static class MayBeEnumerableExtensions
    {
        public static MayBe<IEnumerable<T>> ForEach<T>(this MayBe<IEnumerable<T>> source, Action<T> action)
        {
            if (!source.HasValue) return source;
            
            foreach (var item in source.Value)
            {
                action.Invoke(item);
            }

            return source;
        }

        public static MayBe<IEnumerable<T>> IfNotEmpty<T>(this MayBe<IEnumerable<T>> source)
        {
            return WhenNotEmpty(source);
        }

        public static MayBe<IEnumerable<T>> WhenNotEmpty<T>(this MayBe<IEnumerable<T>> source)
        {
            return WhenHasItem(source);
        }

        public static MayBe<IEnumerable<T>> WhenHasItem<T>(this MayBe<IEnumerable<T>> source)
        {
            if (!source.HasValue) return source;

            return source.Value.Any() ? source : MayBe<IEnumerable<T>>.None;
        }

        public static MayBe<IEnumerable<TOutput>> Select<TInput, TOutput>(this MayBe<IEnumerable<TInput>> source,
            Func<TInput, TOutput> selector)
        {
            return !source.HasValue 
                    ? MayBe<IEnumerable<TOutput>>.None 
                    : source.Value.Select(selector.Invoke).MayBe();
        }

        public static MayBe<IEnumerable<TOutput>> SelectMany<TInput, TOutput>(this MayBe<IEnumerable<TInput>> source,
            Func<TInput, IEnumerable<TOutput>> selector)
        {
            if (!source.HasValue) return MayBe<IEnumerable<TOutput>>.None;

            var result = from s in source.Value
                         from item in selector.Invoke(s)
                         select item;

            return result.MayBe();
        } 
    }
}