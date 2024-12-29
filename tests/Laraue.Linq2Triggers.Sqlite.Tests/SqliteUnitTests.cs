using Laraue.Linq2Triggers.Tests.Tests;

namespace Laraue.Linq2Triggers.Sqlite.Tests;

public class SqliteUnitTests : BaseUnitTests, IMemberAssignmentTests
{
    public SqliteUnitTests() : base(SqliteServices.ServiceProvider)
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
            "INSERT INTO \"DestinationEntity\" (\"GuidValue\") SELECT lower(hex(randomblob(4))) || '-' || "
            + "lower(hex(randomblob(2))) || '-4' || substr(lower(hex(randomblob(2))),2) || '-' || "
            + "substr('89ab', abs(random()) % 4 + 1, 1) || substr(lower(hex(randomblob(2))),2) || '-' || "
            + "lower(hex(randomblob(6)));");
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
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT DATETIME('now', 'localtime');");
    }

    [Fact]
    public void DateTimeOffsetUtcNow_ShouldTranslatesToSql_Always()
    {
        AssertSql(
            MemberAssignmentExpressions.SetDateTimeOffsetUtcNowExpression,
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT DATETIME('now');");
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
            "INSERT INTO \"DestinationEntity\" (\"DateTimeOffsetValue\") SELECT '0001-01-01T00:00:00+00:00';");
    }
}