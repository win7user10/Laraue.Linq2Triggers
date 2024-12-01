using Laraue.Linq2Triggers.TriggerBuilders.TableRefs;

namespace Laraue.Linq2Triggers.TriggerBuilders;

public class UpdateTrigger<TTriggerEntity> : Trigger<TTriggerEntity, OldAndNewTableRefs<TTriggerEntity>>
    where TTriggerEntity : class
{
    public UpdateTrigger(TriggerTime triggerTime)
        : base(TriggerEvent.Update, triggerTime)
    {
    }
}