using System.Linq.Expressions;
using Laraue.Linq2Triggers.Tests.DataAccess;
using Laraue.Linq2Triggers.TriggerBuilders.TableRefs;

namespace Laraue.Linq2Triggers.Tests.Tests
{
    /// <summary>
    /// Tests of translating <see cref="MemberAssignment"/> to SQL code.
    /// </summary>
    public static class MemberAssignmentExpressions
    {
        /// <summary>
        /// EnumValue = Old.EnumValue
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetEnumValueExpression =
            tableRefs => new DestinationEntity
            {
                EnumValue = tableRefs.New.EnumValue
            };

        /// <summary>
        /// DecimalValue = Old.DecimalValue + 3
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> AddDecimalValueExpression =
            tableRefs => new DestinationEntity
            {
                DecimalValue = tableRefs.New.DecimalValue + 3
            };

        /// <summary>
        /// DoubleValue = Old.DoubleValue + 3
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SubDoubleValueExpression =
            tableRefs => new DestinationEntity
            {
                DoubleValue = tableRefs.New.DoubleValue + 3
            };

        /// <summary>
        /// NEW.DoubleValue = Old.DoubleValue + 3
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> MultiplyIntValueExpression =
            tableRefs => new DestinationEntity
            {
                IntValue = tableRefs.New.IntValue * 2
            };

        /// <summary>
        /// BooleanValue = true
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetBooleanValueExpression =
            tableRefs => new DestinationEntity
            {
                BooleanValue = !tableRefs.New.BooleanValue
            };

        /// <summary>
        /// GuidValue = xxxxxxxx-xxxxxx-xxxxxx-xxxxxxxx
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetNewGuidValueExpression =
            tableRefs => new DestinationEntity
            {
                GuidValue = Guid.NewGuid()
            };
        
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetCharVariableExpression =
            tableRefs => new DestinationEntity
            {
                CharValue = tableRefs.New.CharValue
            };
        
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetCharValueExpression =
            tableRefs => new DestinationEntity
            {
                CharValue = 'a'
            };
        
        /// <summary>
        /// DateTimeOffsetValue = DateTimeOffset.UtcNow
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetDateTimeOffsetUtcNowExpression =
            tableRefs => new DestinationEntity
            {
                DateTimeOffsetValue = DateTimeOffset.UtcNow,
            };
        
        /// <summary>
        /// DateTimeOffsetValue = DateTimeOffset.Now
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetDateTimeOffsetNowExpression =
            tableRefs => new DestinationEntity
            {
                DateTimeOffsetValue = DateTimeOffset.Now,
            };
        
        /// <summary>
        /// DateTime = new DateTime()
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetNewDateTimeExpression =
            tableRefs => new DestinationEntity
            {
                DateTimeValue = new DateTime()
            };
        
        /// <summary>
        /// DateTime = new DateTime()
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> SetNewDateTimeOffsetExpression =
            tableRefs => new DestinationEntity
            {
                DateTimeOffsetValue = new DateTimeOffset()
            };
        
        /// <summary>
        /// IntValue = SELECT count(*) FROM DestinationEntities WHERE DestinationEntities.IntValue > 1
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> CountRelatedWithPredicateExpression =
            tableRefs => new DestinationEntity
            {
                IntValue = tableRefs.New.RelatedEntities.Count(x => x.IntValue > 1)
            };
        
        /// <summary>
        /// IntValue = SELECT count(*) FROM DestinationEntities WHERE DestinationEntities.IntValue
        /// more than 1 AND DestinationEntities.IntValue less than 3
        /// </summary>
        public static readonly Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> CountRelatedWithWherePredicateExpression =
            tableRefs => new DestinationEntity
            {
                IntValue = tableRefs.New.RelatedEntities
                    .Where(x => x.IntValue < 3)
                    .Count(x => x.IntValue > 1),
            };
    }
}