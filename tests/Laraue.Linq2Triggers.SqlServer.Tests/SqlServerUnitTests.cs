using Laraue.Linq2Triggers.Tests.Tests;
using Xunit;

namespace Laraue.Linq2Triggers.SqlServer.Tests;

public class SqlServerUnitTests : BaseUnitTests, IMemberAssignmentTests
{
    public SqlServerUnitTests() : base(SqlServerServices.ServiceProvider)
    {
    }

    [Fact]
    public void EnumValue_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetEnumValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"EnumValue\") SELECT @NewEnumValue;");
    }

    [Fact]
    public void DecimalValue_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.AddDecimalValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"DecimalValue\") SELECT @NewDecimalValue + 3;");
    }

    [Fact]
    public void Double_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SubDoubleValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"DoubleValue\") SELECT @NewDoubleValue + 3;");
    }

    [Fact]
    public void IntegerMultiply_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.MultiplyIntValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"IntValue\") SELECT @NewIntValue * 2;");
    }

    [Fact]
    public void BooleanValue_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetBooleanValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"BooleanValue\") SELECT CASE WHEN @NewBooleanValue = 0 THEN 1 ELSE 0 END;");
    }

    [Fact]
    public void NewGuid_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetNewGuidValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"GuidValue\") SELECT NEWID();");
    }

    [Fact]
    public void CharValue_ShouldTranslatesToSql_WhenItSetsAsReference()
    {
        AssertSql(
            MemberAssignmentExpressions.SetCharVariableExpression,
            "INSERT INTO \"DestinationEntity\" (\"CharValue\") SELECT @NewCharValue;");
    }

    [Fact]
    public void CharValue_ShouldTranslatesToSql_WhenItSetsAsValue()
    {
        AssertSql(
            MemberAssignmentExpressions.SetCharValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"CharValue\") SELECT 'a';");
    }

    [Fact]
    public void DateTimeOffsetNow_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetDateTimeOffsetNowExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT SYSDATETIME();");
    }

    [Fact]
    public void DateTimeOffsetUtcNow_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetDateTimeOffsetUtcNowExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT SYSUTCDATETIME();");
    }

    [Fact]
    public void NewDateTime_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetNewDateTimeExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeValue\") SELECT '1753-01-01';");
    }

    [Fact]
    public void NewDateTimeOffset_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetNewDateTimeOffsetExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT '1753-01-01';");
    }

    [Fact]
    public void Count_ShouldTranslatesToSql_WhenItCalculatesOnRelatedEntity()
    {
        AssertSql(
            MemberAssignmentExpressions.CountRelatedWithPredicateExpression,
            """
            INSERT INTO "DestinationEntity" ("IntValue") SELECT (
              SELECT count(*)
              FROM "RelatedEntity"
              INNER JOIN "SourceEntity" ON "RelatedEntity"."SourceEntityId" = "SourceEntity"."Id" AND "RelatedEntity"."SourceEntityId" = @NewId AND "RelatedEntity"."IntValue" > 1);
            """);
    }

    [Fact]
    public void Count_ShouldTranslatesToSql_WhenItCalculatesOnRelatedEntityWithWherePredicate()
    {
        AssertSql(
            MemberAssignmentExpressions.CountRelatedWithWherePredicateExpression,
            """
            INSERT INTO "DestinationEntity" ("IntValue") SELECT (
              SELECT count(*)
              FROM "RelatedEntity"
              INNER JOIN "SourceEntity" ON "RelatedEntity"."SourceEntityId" = "SourceEntity"."Id" AND "RelatedEntity"."SourceEntityId" = @NewId AND "RelatedEntity"."IntValue" < 3 AND "RelatedEntity"."IntValue" > 1);
            """);
    }
}