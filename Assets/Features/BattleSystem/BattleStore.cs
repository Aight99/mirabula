using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BattleSystem
{
    public enum GameState
    {
        Wait,
        Play
    }

    public class BattleStore : IBattleContext
    {
        public static IBattleContext context { get; private set; }
        public GameState state { get; }
        private List<Creature> creatureList { get; }
        public ReadOnlyCollection<Creature> creatures => new(creatureList);

        public BattleStore
        (
            GameState state,
            List<Creature> creatureList
        )
        {
            this.state = state;
            this.creatureList = creatureList;
            context ??= this;
        }

        public static BattleStore Reduce(BattleStore store)
        {
            return new BattleStore(GameState.Play, new(store.creatures));
        }
    }
}