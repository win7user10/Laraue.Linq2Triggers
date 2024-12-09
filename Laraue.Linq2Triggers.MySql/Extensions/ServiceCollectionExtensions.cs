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
using Laraue.Linq2Triggers.MySql.Converters.MemberAccess.DateTime;
using Laraue.Linq2Triggers.MySql.Converters.MethodCalls.Guid.NewGuid;
using Laraue.Linq2Triggers.MySql.Converters.NewExpression;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.TriggerBuilders.Actions;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors.Statements;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.MySql.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
        /// Add EF Core triggers PostgreSQL provider services.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddMySqlTriggerServices(this IServiceCollection services)
        {
            return services
                .AddDefaultServices()
                .AddScoped<SqlTypeMappings, MySqlTypeMappings>()
                .AddScoped<ITriggerVisitor, MySqlTriggerVisitor>()
                .AddTriggerActionVisitor<TriggerUpsertAction, MySqlTriggerUpsertActionVisitor>()
                .AddScoped<IInsertExpressionVisitor, MySqlInsertExpressionVisitor>()
                .AddScoped<ISqlGenerator, MySqlSqlGenerator>()
                .AddTriggerActionVisitor<TriggerActionsGroup, MySqlTriggerActionsGroupVisitor>()
                .AddMethodCallConverter<ConcatStringViaConcatFuncVisitor>()
                .AddMethodCallConverter<StringToUpperViaUpperFuncVisitor>()
                .AddMethodCallConverter<StringToLowerViaLowerFuncVisitor>()
                .AddMethodCallConverter<StringTrimViaTrimFuncVisitor>()
                .AddMethodCallConverter<StringContainsViaInstrFuncVisitor>()
                .AddMethodCallConverter<StringEndsWithViaConcatFuncVisitor>()
                .AddMethodCallConverter<StringIsNullOrEmptyVisitor>()
                .AddMethodCallConverter<MathAbsVisitor>()
                .AddMethodCallConverter<MathAcosVisitor>()
                .AddMethodCallConverter<MathAsinVisitor>()
                .AddMethodCallConverter<MathAtanVisitor>()
                .AddMethodCallConverter<MathAtan2Visitor>()
                .AddMethodCallConverter<MathCeilingVisitor>()
                .AddMethodCallConverter<MathCosVisitor>()
                .AddMethodCallConverter<MathExpVisitor>()
                .AddMethodCallConverter<MathFloorVisitor>()
                .AddMethodCallConverter<NewGuidVisitor>()
                .AddMemberAccessConverter<UtcNowVisitor>()
                .AddMemberAccessConverter<NowVisitor>()
                .AddMemberAccessConverter<Linq2Triggers.MySql.Converters.MemberAccess.DateTimeOffset.UtcNowVisitor>()
                .AddMemberAccessConverter<Linq2Triggers.MySql.Converters.MemberAccess.DateTimeOffset.NowVisitor>()
                .AddNewExpressionConverter<NewDateTimeExpressionVisitor>()
                .AddNewExpressionConverter<NewDateTimeOffsetExpressionVisitor>();
        }
}