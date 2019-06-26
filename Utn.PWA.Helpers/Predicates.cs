using System;
using System.Linq;
using System.Linq.Expressions;

namespace Utn.PWA.Helpers
{
    public static class OwnExtensionMethos
    {
        public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, int property, Expression<Func<T, bool>> predicate)
        {
            if (property > 0)
            {
                return query.Where(predicate);
            }

            return query;
        }

        public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, string property, Expression<Func<T, bool>> predicate)
        {
            if (!string.IsNullOrWhiteSpace(property))
            {
                return query.Where(predicate);
            }

            return query;
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> query, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return query.Where(predicate);

            return query;
        }
    }
}