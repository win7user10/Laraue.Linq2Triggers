using Laraue.Linq2Triggers.Tests.Tests;

namespace Laraue.Linq2Triggers.PostgreSql.Tests;

public class PostgreSqlUnitTests : BaseUnitTests, IMemberAssignmentTests
{
    public PostgreSqlUnitTests() : base(PostgreSqlServices.ServiceProvider)
    {
    }

    [Fact]
    public void EnumValue_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetEnumValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"EnumValue\") SELECT NEW.\"EnumValue\";");
    }

    [Fact]
    public void DecimalValue_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.AddDecimalValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"DecimalValue\") SELECT NEW.\"DecimalValue\" + 3;");
    }

    [Fact]
    public void Double_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SubDoubleValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"DoubleValue\") SELECT NEW.\"DoubleValue\" + 3;");
    }

    [Fact]
    public void IntegerMultiply_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.MultiplyIntValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"IntValue\") SELECT NEW.\"IntValue\" * 2;");
    }

    [Fact]
    public void BooleanValue_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetBooleanValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"BooleanValue\") SELECT NEW.\"BooleanValue\" IS FALSE;");
    }

    [Fact]
    public void NewGuid_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetNewGuidValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"GuidValue\") SELECT gen_random_uuid();");
    }

    [Fact]
    public void CharValue_ShouldTranslatesToSql_WhenItSetsAsReference()
    {
        AssertSql(
            MemberAssignmentExpressions.SetCharVariableExpression,
            "INSERT INTO \"DestinationEntity\" (\"CharValue\") SELECT NEW.\"CharValue\";");
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
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT NOW();");
    }

    [Fact]
    public void DateTimeOffsetUtcNow_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetDateTimeOffsetUtcNowExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT CURRENT_TIMESTAMP;");
    }

    [Fact]
    public void NewDateTime_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetNewDateTimeExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeValue\") SELECT '0001-01-01';");
    }

    [Fact]
    public void NewDateTimeOffset_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetNewDateTimeOffsetExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT '0001-01-01';");
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
              INNER JOIN "SourceEntity" ON "RelatedEntity"."SourceEntityId" = "SourceEntity"."Id" AND "RelatedEntity"."SourceEntityId" = NEW."Id" AND "RelatedEntity"."IntValue" > 1);
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
              INNER JOIN "SourceEntity" ON "RelatedEntity"."SourceEntityId" = "SourceEntity"."Id" AND "RelatedEntity"."SourceEntityId" = NEW."Id" AND "RelatedEntity"."IntValue" < 3 AND "RelatedEntity"."IntValue" > 1);
            """);
    }
}