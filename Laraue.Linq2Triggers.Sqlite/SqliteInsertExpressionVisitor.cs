using System.Linq;
using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.TriggerBuilders;
using Laraue.Linq2Triggers.Visitors.SetExpressionVisitors;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors.Statements;

namespace Laraue.Linq2Triggers.Sqlite;

/// <inheritdoc />
public sealed class SqliteInsertExpressionVisitor : InsertExpressionVisitor
{
    private readonly IDbSchemaRetriever _adapter;
    private readonly ISqlGenerator _sqlGenerator;

    /// <inheritdoc />
    public SqliteInsertExpressionVisitor(
        IMemberInfoVisitorFactory factory,
        IDbSchemaRetriever adapter,
        ISqlGenerator sqlGenerator) 
        : base(factory, sqlGenerator)
    {
        _adapter = adapter;
        _sqlGenerator = sqlGenerator;
    }

    /// <inheritdoc />
    protected override SqlBuilder VisitEmptyInsertBody(LambdaExpression insertExpression)
    {
        var insertType = insertExpression.Body.Type;
        
        var primaryKeyProperties = _adapter.GetPrimaryKeyMembers(insertType);
        
        var sqlBuilder = SqlBuilder.FromString("(")
            .AppendJoin(", ", primaryKeyProperties
                .Select(propertyInfo => _sqlGenerator
                    .GetColumnSql(insertType, propertyInfo, ArgumentType.None)))
            .Append(") VALUES (")
            .AppendJoin(", ", primaryKeyProperties.Select(_ => "NULL"))
            .Append(")");

        return sqlBuilder;
    }
}