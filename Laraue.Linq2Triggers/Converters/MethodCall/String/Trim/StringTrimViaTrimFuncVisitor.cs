using System.Collections.Generic;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Trim
{
    /// <inheritdoc />
    public class StringTrimViaTrimFuncVisitor : BaseStringTrimVisitor
    {
        /// <inheritdoc />
        protected override IEnumerable<string> SqlTrimFunctionsNamesToApply { get; } = new[]
        {
            "TRIM"
        };
        
        /// <inheritdoc />
        public StringTrimViaTrimFuncVisitor(IExpressionVisitorFactory visitorFactory)
            : base(visitorFactory)
        {
        }
    }
}