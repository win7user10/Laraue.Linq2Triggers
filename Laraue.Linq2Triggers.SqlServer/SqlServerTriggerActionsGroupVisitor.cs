﻿using System.Linq;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors;

namespace Laraue.Linq2Triggers.SqlServer;

public sealed class SqlServerTriggerActionsGroupVisitor : BaseTriggerActionsGroupVisitor
{
    public SqlServerTriggerActionsGroupVisitor(ITriggerActionVisitorFactory factory)
        : base(factory)
    {
    }

    protected override SqlBuilder GetActionSql(SqlBuilder[] actionsSql, SqlBuilder[] conditionsSql)
    {
        var sql = new SqlBuilder();
        
        if (conditionsSql.Length > 0)
        {
            sql.Append($"IF (")
                .AppendJoin(" AND ", conditionsSql.Select(x => x.ToString()))
                .Append(")")
                .AppendNewLine();
        }
        
        return sql.AppendViaNewLine(actionsSql);
    }
}