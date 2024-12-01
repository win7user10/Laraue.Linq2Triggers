﻿namespace Laraue.Linq2Triggers.PostgreSql.Tests
{
    public class DestinationEntity
    {
        public decimal? DecimalValue { get; set; }
        public double? DoubleValue { get; set; }
        public int? IntValue { get; set; }
        public bool? BooleanValue { get; set; }
        public Guid? GuidValue { get; set; }

        public int? UniqueIdentifier { get; set; }
        public DateTime? DateTimeValue { get; set; }
    }
}