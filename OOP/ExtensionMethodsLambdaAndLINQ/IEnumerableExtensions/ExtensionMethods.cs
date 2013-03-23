using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IEnumerableExtensions
{
    public static class ExtensionMethods
    {
        #region Private Methods

        private static T EvaluateExpression<T>(this IEnumerable<T> source, Func<T, T, T> function)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }

            IEnumerator<T> enumerator = source.GetEnumerator();
            T element;
            enumerator.MoveNext();

            try
            {
                element = enumerator.Current;
            }
            catch (InvalidOperationException e) // If the enumeration is empty
            {
                if (typeof(IFormattable).IsAssignableFrom(typeof(T)))
                {
                    throw new InvalidOperationException(e.Message, e.InnerException);
                }

                return default(T);
            }

            while (enumerator.MoveNext())
            {
                element = function(element, enumerator.Current);
            }

            return element;
        }

        #endregion

        #region Public Methods

        public static int Count<T>(this IEnumerable<T> source)
        {
            int counter = 1;

            try
            {
                //Lambda with closure
                T result = source.EvaluateExpression<T>((x, y) => { counter++; return x; });

                //If the enumration has 0 items
                if (result == null)
                {
                    counter = 0;
                }
            }
            catch (InvalidOperationException) //if the enumeration has 0 items and a number
            {
                counter = 0;
            }

            return counter;
        }

        public static T Max<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            return source.EvaluateExpression<T>((x, y) => x.CompareTo(y) > 0 ? x : y);
        }

        public static T Min<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            return source.EvaluateExpression<T>((x, y) => x.CompareTo(y) < 0 ? x : y);
        }

        public static T Sum<T>(this IEnumerable<T> source)
        {
            return source.EvaluateExpression<T>((x, y) => x + (dynamic)y);
        }

        public static decimal Average<T>(this IEnumerable<T> source) where T : IComparable<T>, IFormattable
        {
            return (dynamic)source.Sum<T>() / (decimal)source.Count<T>();
        }

        public static T Product<T>(this IEnumerable<T> source) where T : IComparable<T>, IFormattable
        {
            Type type = typeof(T);

            // Parameter Expressions
            var a = Expression.Parameter(type);
            var b = Expression.Parameter(type);

            // Binary Expression
            var multiplication = Expression.Multiply(a, b);

            // Lambda Expression Tree for multiplication
            var lambda = Expression.Lambda<Func<T, T, T>>(multiplication, a, b);

            // Compile it into delegate (Func<T, T, T>)
            var multiplicationFunc = lambda.Compile();

            return source.EvaluateExpression<T>(multiplicationFunc);
        }

        #endregion
    }
}
