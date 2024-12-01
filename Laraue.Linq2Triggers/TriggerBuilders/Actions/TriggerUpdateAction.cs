﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.TriggerBuilders.Abstractions;

namespace Laraue.Linq2Triggers.TriggerBuilders.Actions
{
    /// <summary>
    /// Trigger update action.
    /// </summary>
    public sealed class TriggerUpdateAction : ITriggerAction
    {
        /// <summary>
        /// Predicate for an action, e.g. NEW.Age > 21
        /// </summary>
        public readonly LambdaExpression Predicate;
        
        /// <summary>
        /// Expression describes update, e.g. tableRefs => new User { Age = tableRefs.Old.Age }
        /// </summary>
        public readonly LambdaExpression UpdateExpression;

        /// <summary>
        /// Initializes a new instance of <see cref="TriggerUpdateAction"/>.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="updateExpression"></param>
        public TriggerUpdateAction(
            LambdaExpression predicate,
            LambdaExpression updateExpression)
        {
            Predicate = predicate;
            UpdateExpression = updateExpression;
        }
    }
}