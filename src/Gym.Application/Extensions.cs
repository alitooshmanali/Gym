using System.Collections;
using System.Linq.Expressions;

namespace Gym.Application;

public static class Extensions
{
    public static T Invoke<T>(this Expression expression)
        => (T)Expression.Lambda(expression).Compile().DynamicInvoke();

    public static Expression ApplyPaging(this Expression expression, int pageSize, int pageIndex)
    {
        if (pageSize == -1 && pageIndex == -1)
            return expression;

        if (pageSize == 0) pageSize = 30;
        if (pageIndex == 0) pageIndex = 1;

        var start = pageSize * (pageIndex - 1);
        var baseMethodCallType = expression.ToBaseMethodCallType();
        var elementType = expression.ToElementType();

        expression = Expression.Call(
            baseMethodCallType,
            "Skip",
            new[] { elementType },
            expression,
            Expression.Constant(start, typeof(int)));

        expression = Expression.Call(
            baseMethodCallType,
            "Take",
            new[] { elementType },
            expression,
            Expression.Constant(pageSize, typeof(int)));

        return expression;
    }

    public static Expression ApplyTotalCount(this Expression expression)
    {
        return Expression.Call(
            expression.ToBaseMethodCallType(),
            nameof(Queryable.LongCount),
            new[] { expression.ToElementType() },
            expression);
    }

    private static Type ToElementType(this Expression expression)
    {
        return expression.Type.HasElementType
            ? expression.Type.GetElementType()
            : expression.Type.GenericTypeArguments[0];
    }

    private static Type ToBaseMethodCallType(this Expression expression)
    {
        if (typeof(IQueryable).IsAssignableFrom(expression.Type))
            return typeof(Queryable);

        if (!typeof(IEnumerable).IsAssignableFrom(expression.Type))
            return null;

        return typeof(Enumerable);
    }
}