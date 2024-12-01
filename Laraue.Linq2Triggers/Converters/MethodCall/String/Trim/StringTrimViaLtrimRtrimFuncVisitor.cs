using System.Collections.Generic;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Trim
{
    /// <inheritdoc />
    public class StringTrimViaLtrimRtrimFuncVisitor : BaseStringTrimVisitor
    {
        /// <inheritdoc />
        protected override IEnumerable<string> SqlTrimFunctionsNamesToApply { get; } = new []
        {
            "LTRIM",
            "RTRIM"
        };
        
        /// <inheritdoc />
        public StringTrimViaLtrimRtrimFuncVisitor(IExpressionVisitorFactory visitorFactory)
            : base(visitorFactory)
        {
        }
    }
}