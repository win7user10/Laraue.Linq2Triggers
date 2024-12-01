using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Math.Atan2
{
    /// <inheritdoc />
    public class MathAtan2Visitor : BaseAtan2Visitor
    {
        /// <inheritdoc />
        protected override string SqlFunctionName => "ATAN2";
        
        /// <inheritdoc />
        public MathAtan2Visitor(IExpressionVisitorFactory visitorFactory)
            : base(visitorFactory)
        {
        }
    }
}
