using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BattleSystem
{
    public struct CreaturePosition
    {
        public int spotIndex;
        public bool isEnemy => spotIndex > 4;

        public CreaturePosition(int spotIndex = 0)
        {
            this.spotIndex = spotIndex;
        }
    }

    public struct CreatureInfo
    {
        public string assetId;
        public string name;
        public int health;
        public int maxHealth;

        public CreatureInfo
        (
            string assetId,
            string name,
            int health,
            int maxHealth
        )
        {
            this.assetId = assetId;
            this.name = name;
            this.health = health;
            this.maxHealth = maxHealth;
        }
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

        public static Creature Reduce(Creature creature)
        {
            var newInfo = creature.info;
            var newPosition = creature.position;

            EffectTrigger trigger = new OnApplyEffect();

            switch (trigger)
            {
                case OnApplyEffect onApply:
                    break;
                case OnStartEffect onStart:
                    break;
            }

            return new Creature(creature.info, creature.position, creature.effects);
        }
    }

    public abstract class EffectTrigger
    {

    }

    public class OnApplyEffect : EffectTrigger
    {

    }

    public class OnStartEffect : EffectTrigger
    {

    }
}
