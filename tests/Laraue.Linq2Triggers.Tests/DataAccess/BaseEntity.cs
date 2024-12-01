namespace Laraue.Linq2Triggers.Tests.DataAccess;

public class BaseEntity
{
    public int Id { get; set; }
    public string? StringField { get; set; }
    public char? CharValue { get; set; }
    public DateTimeOffset? DateTimeOffsetValue { get; set; }
}