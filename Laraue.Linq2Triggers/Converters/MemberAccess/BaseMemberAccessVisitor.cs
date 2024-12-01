using System;
using System.Linq.Expressions;
using Laraue.Linq2Triggers.Converters.MethodCall;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MemberAccess
{
    /// <summary>
    /// Base <see cref="IMethodCallVisitor"/>.
    /// </summary>
    public abstract class BaseMemberAccessVisitor : IMemberAccessVisitor
    {
        /// <summary>
        /// Specifies a method which will be handled by this converter.
        /// </summary>
        protected abstract string PropertyName { get; }
        
        /// <summary>
        /// Specifies a class which methods will be handled by this converter.
        /// </summary>
        protected abstract Type ReflectedType { get; }
        
        /// <summary>
        /// Factory to visit expressions and generate SQL code.
        /// </summary>
        protected IExpressionVisitorFactory VisitorFactory { get; }
        
        /// <summary>
        /// Initialize a new instance of <see cref="BaseMethodCallVisitor"/>.
        /// </summary>
        /// <param name="visitorFactory"></param>
        protected BaseMemberAccessVisitor(IExpressionVisitorFactory visitorFactory)
        {
            VisitorFactory = visitorFactory;
        }
        
        /// <inheritdoc />
        public bool IsApplicable(MemberExpression expression)
        {
            return expression.Member.ReflectedType == ReflectedType && PropertyName == expression.Member.Name;
        }

        /// <inheritdoc />
        public abstract SqlBuilder Visit(MemberExpression expression);
    }
}