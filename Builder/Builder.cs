using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Builder.Test")]
namespace Builder;

public class Builder<T>: IBuildable<T>
{
    private T _instance;

    internal Builder(T instance)
    {
        _instance = instance is null ? Activator.CreateInstance<T>() : instance;
    }

    internal static Builder<T> GetBuilder(T instance)
    {
        return new Builder<T>(instance);
    }

    public Builder<T> With<TType>(Expression<Func<T, TType>> propertySelector, TType value)
    {
        SetPropertyValue(propertySelector, value);
        return this;
    }

    private void SetPropertyValue<TType>(Expression<Func<T, TType>> propertySelector, TType value) {
        
        var memberExpression = propertySelector.Body as MemberExpression;
        if (memberExpression == null)
        {
            throw new ArgumentNullException("Invalid property selector");
        }

        var memberInfo = memberExpression.Member as PropertyInfo;
        if (memberInfo == null)
        { 
            throw new ArgumentNullException("Invalid property selector");
        }
        memberInfo.SetValue(_instance, value); 
        
    }

    public Builder<T> With<TType>(Expression<Func<T, TType>> propertySelector, Func<T, TType> valueProvider)
    {
        SetPropertyValue(propertySelector, valueProvider(_instance));
        return this;
    }

    public T Build()
    {
        // Validate
        
        return _instance;
    }
}