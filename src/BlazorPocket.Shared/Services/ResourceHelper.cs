using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;


namespace BlazorPocket.Shared.Services;

/// <summary>
/// Helper class for retrieving display names of properties using expressions.
/// </summary>
public static class ResourceHelper
{
    /// <summary>
    /// Gets the display name of a property specified by the expression.
    /// </summary>
    /// <typeparam name="T">The type of the object containing the property.</typeparam>
    /// <param name="expression">The expression specifying the property.</param>
    /// <returns>The display name of the property.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the expression is invalid.</exception>
    public static string GetDisplayName<T>(Expression<Func<T, object>> expression)
    {
        if (expression.Body is MemberExpression member)
        {
            return GetDisplayName(member);
        }

        if (expression.Body is UnaryExpression unary && unary.Operand is MemberExpression memberExpression)
        {
            return GetDisplayName(memberExpression);
        }

        throw new InvalidOperationException("Invalid expression");
    }

    private static string GetDisplayName(MemberExpression member)
    {
        var prop = member.Member as PropertyInfo;
        if (prop == null) return member.Member.Name;

        var displayAttribute = prop.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
        return displayAttribute?.GetName() ?? member.Member.Name;
    }
    public static string GetDisplayName<T>(this T instance, Expression<Func<T, object?>> expression)
    {
        var member = GetMemberExpression(expression.Body);
        var prop = member.Member as PropertyInfo;
        if (prop == null) return member.Member.Name;

        var displayAttribute = prop.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
        return displayAttribute?.GetName() ?? member.Member.Name;
    }

    private static MemberExpression GetMemberExpression(Expression expression)
    {
        if (expression is MemberExpression memberExpression)
            return memberExpression;

        if (expression is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
            return operand;

        throw new InvalidOperationException("Invalid expression");
    }

}

