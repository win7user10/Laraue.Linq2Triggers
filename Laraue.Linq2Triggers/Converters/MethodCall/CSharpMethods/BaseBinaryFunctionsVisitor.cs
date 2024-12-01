using System;
using Laraue.Linq2Triggers.CSharpMethods;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.CSharpMethods
{
    /// <summary>
    /// Base visitor for <see cref="System.String"/> methods.
    /// </summary>
    public abstract class BaseBinaryFunctionsVisitor : BaseMethodCallVisitor
    {
        /// <inheritdoc />
        protected override Type ReflectedType => typeof(BinaryFunctions);

        /// <inheritdoc />
        protected BaseBinaryFunctionsVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}