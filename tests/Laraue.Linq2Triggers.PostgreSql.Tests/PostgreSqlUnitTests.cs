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
            MemberAssignmentExpressions.AddDecimalValueExpression,
            "INSERT INTO \"DestinationEntity\" (\"DecimalValue\") SELECT NEW.\"DecimalValue\" + 3;");
    }

    public void DecimalValue_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void Double_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void DoubleSubtract_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void IntegerMultiply_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void BooleanValue_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void NewGuid_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void CharValue_ShouldTranslatesToSql_WhenItSetsAsReference()
    {
        throw new NotImplementedException();
    }

    public void CharValue_ShouldTranslatesToSql_WhenItSetsAsValue()
    {
        throw new NotImplementedException();
    }

    public void DateTimeOffsetNow_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void DateTimeOffsetUtcNow_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void NewDateTime_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }

    public void NewDateTimeOffset_ShouldTranslatesToSql_Always()
    {
        throw new NotImplementedException();
    }
}