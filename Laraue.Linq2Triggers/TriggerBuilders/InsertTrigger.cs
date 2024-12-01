using Laraue.Linq2Triggers.TriggerBuilders.TableRefs;

namespace Laraue.Linq2Triggers.TriggerBuilders;

public class InsertTrigger<TTriggerEntity> : Trigger<TTriggerEntity, NewTableRef<TTriggerEntity>>
    where TTriggerEntity : class
{
    public InsertTrigger(TriggerTime triggerTime)
        : base(TriggerEvent.Insert, triggerTime)
    {
    }
}