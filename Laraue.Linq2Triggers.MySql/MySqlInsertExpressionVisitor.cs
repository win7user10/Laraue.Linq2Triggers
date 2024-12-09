using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.SetExpressionVisitors;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors.Statements;

namespace Laraue.Linq2Triggers.MySql;

/// <inheritdoc />
public sealed class MySqlInsertExpressionVisitor : InsertExpressionVisitor
{
    /// <inheritdoc />
    public MySqlInsertExpressionVisitor(IMemberInfoVisitorFactory factory, ISqlGenerator sqlGenerator) 
        : base(factory, sqlGenerator)
    {
    }

    /// <inheritdoc />
    protected override SqlBuilder VisitEmptyInsertBody(LambdaExpression insertExpression)
    {
        var sqlBuilder = new SqlBuilder();
        sqlBuilder.Append("() VALUES ()");
        return sqlBuilder;
    }
}