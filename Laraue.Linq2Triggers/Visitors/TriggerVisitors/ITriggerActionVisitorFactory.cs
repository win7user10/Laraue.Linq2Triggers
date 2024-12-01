﻿using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.TriggerBuilders.Abstractions;

namespace Laraue.Linq2Triggers.Visitors.TriggerVisitors
{
    /// <summary>
    /// Factory to get suitable <see cref="ITriggerAction"/> depending on its type.
    /// </summary>
    public interface ITriggerActionVisitorFactory
    {
        /// <summary>
        /// Initialize suitable <see cref="ITriggerAction"/> and call its
        /// <see cref="ITriggerAction.Visit"/>
        /// </summary>
        /// <param name="triggerAction"></param>
        /// <param name="visitedMembers"></param>
        /// <returns></returns>
        SqlBuilder Visit(ITriggerAction triggerAction, VisitedMembers visitedMembers);
    }
}