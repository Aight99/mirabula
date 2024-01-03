using System.Collections.ObjectModel;

namespace BattleSystem
{
    public interface IBattleContext
    {
        GameState state { get; }
        ReadOnlyCollection<Creature> creatures { get; }
    }
}