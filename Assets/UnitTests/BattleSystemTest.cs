using System.Collections.Generic;
using System.Linq;
using BattleSystem;
using NUnit.Framework;

public class BattleSystemTest
{
    private static BattleStore GetPlainStore() =>
        new BattleStore(GameState.Play, new List<Creature> { new Creature(), new Creature() });

    [Test]
    public void StoreAddCreature()
    {
        var store = GetPlainStore();
        Assert.AreEqual(store.creatures.Count, 2);

        var newCollection = store.creatures.Append(new Creature());

        Assert.AreEqual(store.creatures.Count, 2);
        Assert.AreEqual(newCollection.Count(), 3);
    }
}
