﻿using System.Linq;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors;

namespace Laraue.Linq2Triggers.PostgreSql;

public sealed class PostgreSqlTriggerActionsGroupVisitor : BaseTriggerActionsGroupVisitor
{
    public PostgreSqlTriggerActionsGroupVisitor(ITriggerActionVisitorFactory factory)
        : base(factory)
    {
    }
    
    protected override SqlBuilder GetActionSql(SqlBuilder[] actionsSql, SqlBuilder[] conditionsSql)
    {
        var sql = new SqlBuilder();
        var isAnyCondition = conditionsSql.Length > 0;
        
        if (isAnyCondition)
        {
            sql.AppendNewLine($"IF ")
                .AppendJoin(" AND ", conditionsSql.Select(x => x.ToString()))
                .Append(" THEN ");
        }

        sql.WithIdentWhen(conditionsSql.Length > 0,  loopSql => loopSql.AppendViaNewLine(actionsSql));
        
        if (isAnyCondition)
        {
            sql.AppendNewLine($"END IF;");
        }

        return sql;
    }
}