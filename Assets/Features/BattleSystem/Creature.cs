using System.Collections.Generic;
using System.Collections.ObjectModel;
using PlasticGui.Gluon.WorkspaceWindow.Views.IncomingChanges;

namespace BattleSystem
{
    public struct CreaturePosition
    {
        public int spotIndex;
        public bool isEnemy => spotIndex > 4;
    }

    public struct CreatureInfo
    {
        public string assetId;
        public string name;
        public int health;
        public int maxHealth;
    }

    public readonly struct Creature
    {
        public readonly ReadOnlyCollection<IEffect> effects;
        public readonly CreatureInfo info;
        public readonly CreaturePosition position;

        public Creature
        (
            CreatureInfo info = new CreatureInfo(),
            CreaturePosition position = new CreaturePosition(),
            ReadOnlyCollection<IEffect> effects = null
        )
        {
            this.info = info;
            this.position = position;
            this.effects = effects ?? new List<IEffect>().AsReadOnly();
        }

        public void ApplyEffect(IEffect effect)
        {
            effect.Transform(this);
        }
    }
}
