using System;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String
{
    /// <summary>
    /// Base visitor for <see cref="System.String"/> methods.
    /// </summary>
    public abstract class BaseStringVisitor : BaseMethodCallVisitor
    {
        /// <inheritdoc />
        protected override Type ReflectedType => typeof(string);

        /// <inheritdoc />
        protected BaseStringVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}