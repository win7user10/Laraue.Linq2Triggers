﻿using Laraue.Linq2Triggers.Converters.MethodCall.Math.Abs;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Acos;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Asin;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Atan;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Atan2;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Ceiling;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Cos;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Exp;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Floor;
using Laraue.Linq2Triggers.Converters.MethodCall.String.Concat;
using Laraue.Linq2Triggers.Converters.MethodCall.String.Contains;
using Laraue.Linq2Triggers.Converters.MethodCall.String.EndsWith;
using Laraue.Linq2Triggers.Converters.MethodCall.String.IsNullOrEmpty;
using Laraue.Linq2Triggers.Converters.MethodCall.String.ToLower;
using Laraue.Linq2Triggers.Converters.MethodCall.String.ToUpper;
using Laraue.Linq2Triggers.Converters.MethodCall.String.Trim;
using Laraue.Linq2Triggers.Extensions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Sqlite.Converters.MethodCalls.Guid.NewGuid;
using Laraue.Linq2Triggers.Sqlite.Converters.NewExpression;
using Laraue.Linq2Triggers.TriggerBuilders.Actions;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors.Statements;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.Sqlite.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add EF Core triggers SQLite provider services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqliteServices(this IServiceCollection services)
        {
            return services.AddDefaultServices()
                .AddScoped<SqlTypeMappings, SqliteTypeMappings>()
                .AddScoped<ITriggerVisitor, SqliteTriggerVisitor>()
                .AddTriggerActionVisitor<TriggerUpsertAction, TriggerUpsertActionVisitor>()
                .AddScoped<IInsertExpressionVisitor, SqliteInsertExpressionVisitor>()
                .AddScoped<ISqlGenerator, SqlGenerator>()
                .AddTriggerActionVisitor<TriggerActionsGroup, SqliteTriggerActionsGroupVisitor>()
                .AddMethodCallConverter<ConcatStringViaDoubleVerticalLineVisitor>()
                .AddMethodCallConverter<StringToUpperViaUpperFuncVisitor>()
                .AddMethodCallConverter<StringToLowerViaLowerFuncVisitor>()
                .AddMethodCallConverter<StringTrimViaTrimFuncVisitor>()
                .AddMethodCallConverter<StringContainsViaInstrFuncVisitor>()
                .AddMethodCallConverter<StringEndsWithViaDoubleVerticalLineVisitor>()
                .AddMethodCallConverter<StringIsNullOrEmptyVisitor>()
                .AddMethodCallConverter<MathAbsVisitor>()
                .AddMethodCallConverter<MathAcosVisitor>()
                .AddMethodCallConverter<MathAsinVisitor>()
                .AddMethodCallConverter<MathAtanVisitor>()
                .AddMethodCallConverter<MathAtan2Visitor>()
                .AddMethodCallConverter<MathCeilVisitor>()
                .AddMethodCallConverter<MathCosVisitor>()
                .AddMethodCallConverter<MathExpVisitor>()
                .AddMethodCallConverter<MathFloorVisitor>()
                .AddMethodCallConverter<NewGuidVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTime.UtcNowVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTime.NowVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTimeOffset.UtcNowVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTimeOffset.NowVisitor>()
                .AddNewExpressionConverter<NewDateTimeSqliteExpressionVisitor>()
                .AddNewExpressionConverter<NewDateTimeOffsetSqliteExpressionVisitor>();
        }
    }
}