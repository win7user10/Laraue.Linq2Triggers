using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.TriggerBuilders.Abstractions;

namespace Laraue.Linq2Triggers.Visitors.TriggerVisitors
{
    /// <summary>
    /// Visitor for the <see cref="ITriggerAction"/>. 
    /// </summary>
    /// <typeparam name="TTriggerAction"></typeparam>
    public interface ITriggerActionVisitor<in TTriggerAction>
        where TTriggerAction : ITriggerAction
    {
        /// <summary>
        /// Visit <see cref="ITriggerAction"/> and return new SQL for it.
        /// </summary>
        /// <param name="triggerAction"></param>
        /// <param name="visitedMembers"></param>
        /// <returns></returns>
        SqlBuilder Visit(TTriggerAction triggerAction, VisitedMembers visitedMembers);
    }
}