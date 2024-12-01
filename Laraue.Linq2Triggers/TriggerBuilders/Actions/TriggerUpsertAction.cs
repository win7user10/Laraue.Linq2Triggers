﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.TriggerBuilders.Abstractions;

namespace Laraue.Linq2Triggers.TriggerBuilders.Actions
{
    /// <summary>
    /// Trigger upsert action.
    /// </summary>
    public sealed class TriggerUpsertAction : ITriggerAction
    {
        /// <summary>
        /// Predicate, describes when the action should work as insert and when as update.
        /// E.g. User.Where(x => x.Id = 15). If the any user will found, update will be
        /// performed, else insert.
        /// </summary>
        public readonly LambdaExpression MatchExpression;
        
        /// <summary>
        /// The entity should be inserted expression, tableRefs => new User { Age = tableRefs.Old.Age }.
        /// </summary>
        public readonly LambdaExpression InsertExpression;
        
        /// <summary>
        /// Expression describes update, e.g. tableRefs => new User { Age = tableRefs.Old.Age }
        /// </summary>
        public readonly LambdaExpression? UpdateExpression;

        /// <summary>
        /// Initializes a new instance of <see cref="TriggerUpsertAction"/>.
        /// </summary>
        /// <param name="matchExpression"></param>
        /// <param name="insertExpression"></param>
        /// <param name="updateExpression"></param>
        public TriggerUpsertAction(
            LambdaExpression matchExpression,
            LambdaExpression insertExpression,
            LambdaExpression? updateExpression)
        {
            MatchExpression = matchExpression;
            InsertExpression = insertExpression;
            UpdateExpression = updateExpression;
        }
    }
}