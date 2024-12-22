using System;
using System.Linq.Expressions;
using Laraue.Linq2Triggers.Converters.MethodCall.Math.Abs;
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
using Laraue.Linq2Triggers.SqlServer.Converters.MethodCalls.Guid.NewGuid;
using Laraue.Linq2Triggers.SqlServer.Converters.NewExpression;
using Laraue.Linq2Triggers.TriggerBuilders.Actions;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors.Statements;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add EF Core triggers SQL Server provider services.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddSqlServerServices(this IServiceCollection services)
        {
            return services.AddDefaultServices()
                .AddScoped<SqlTypeMappings, SqlServerTypeMappings>()
                .AddExpressionVisitor<UnaryExpression, SqlServerUnaryExpressionVisitor>()
                .AddScoped<IInsertExpressionVisitor, InsertExpressionVisitor>()
                .AddTriggerActionVisitor<TriggerUpsertAction, SqlServerTriggerUpsertActionVisitor>()
                .AddScoped<ISqlGenerator, SqlServerSqlGenerator>()
                .AddScoped<ITriggerVisitor, SqlServerTriggerVisitor>()
                .AddTriggerActionVisitor<TriggerActionsGroup, SqlServerTriggerActionsGroupVisitor>()
                .AddMethodCallConverter<ConcatStringViaPlusVisitor>()
                .AddMethodCallConverter<StringToUpperViaUpperFuncVisitor>()
                .AddMethodCallConverter<StringToLowerViaLowerFuncVisitor>()
                .AddMethodCallConverter<StringTrimViaLtrimRtrimFuncVisitor>()
                .AddMethodCallConverter<StringContainsViaCharindexFuncVisitor>()
                .AddMethodCallConverter<StringEndsWithViaPlusVisitor>()
                .AddMethodCallConverter<StringIsNullOrEmptyVisitor>()
                .AddMethodCallConverter<MathAbsVisitor>()
                .AddMethodCallConverter<MathAcosVisitor>()
                .AddMethodCallConverter<MathAsinVisitor>()
                .AddMethodCallConverter<MathAtanVisitor>()
                .AddMethodCallConverter<MathAtn2Visitor>()
                .AddMethodCallConverter<MathCeilingVisitor>()
                .AddMethodCallConverter<MathCosVisitor>()
                .AddMethodCallConverter<MathExpVisitor>()
                .AddMethodCallConverter<MathFloorVisitor>()
                .AddMethodCallConverter<NewGuidVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTime.UtcNowVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTime.NowVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTimeOffset.UtcNowVisitor>()
                .AddMemberAccessConverter<Converters.MemberAccess.DateTimeOffset.NowVisitor>()
                .AddNewExpressionConverter<NewDateTimeExpressionVisitor>()
                .AddNewExpressionConverter<NewDateTimeOffsetExpressionVisitor>();
        }
    }
}