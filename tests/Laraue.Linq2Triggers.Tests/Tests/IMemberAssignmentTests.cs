namespace Laraue.Linq2Triggers.Tests.Tests;

public interface IMemberAssignmentTests
{
    void EnumValue_ShouldTranslatesToSql_Always();
    void DecimalValue_ShouldTranslatesToSql_Always();
    void Double_ShouldTranslatesToSql_Always();
    void IntegerMultiply_ShouldTranslatesToSql_Always();
    void BooleanValue_ShouldTranslatesToSql_Always();
    void NewGuid_ShouldTranslatesToSql_Always();
    void CharValue_ShouldTranslatesToSql_WhenItSetsAsReference();
    void CharValue_ShouldTranslatesToSql_WhenItSetsAsValue();
    void DateTimeOffsetNow_ShouldTranslatesToSql_Always();
    void DateTimeOffsetUtcNow_ShouldTranslatesToSql_Always();
    void NewDateTime_ShouldTranslatesToSql_Always();
    void NewDateTimeOffset_ShouldTranslatesToSql_Always();
    void Count_ShouldTranslatesToSql_WhenItCalculatesOnRelatedEntity();
    void Count_ShouldTranslatesToSql_WhenItCalculatesOnRelatedEntityWithWherePredicate();
}