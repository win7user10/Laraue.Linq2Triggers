﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.TriggerBuilders.Abstractions;

namespace Laraue.Linq2Triggers.TriggerBuilders.Actions
{
    /// <summary>
    /// Trigger delete action.
    /// </summary>
    public sealed class TriggerDeleteAction : ITriggerAction
    {
        /// <summary>
        /// Predicate to delete, e.g. Users.Where(x => x.Id == 2)
        /// </summary>
        public readonly LambdaExpression Predicate;

        /// <summary>
        /// Initializes a new instance of <see cref="TriggerDeleteAction"/>.
        /// </summary>
        /// <param name="predicate"></param>
        public TriggerDeleteAction(LambdaExpression predicate)
        {
            Predicate = predicate;
        }
    }
}