namespace Laraue.Linq2Triggers.Tests.DataAccess
{
    public class SourceEntity : BaseEntity
    {
        public EnumValue EnumValue { get; set; }
        public decimal DecimalValue { get; set; }
        public double DoubleValue { get; set; }
        public int IntValue { get; set; }
        public bool BooleanValue { get; set; }
        public Guid GuidValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public IList<RelatedEntity> RelatedEntities { get; set; }
    }
}