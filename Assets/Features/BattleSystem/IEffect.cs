using System;

namespace BattleSystem
{
    public interface IEffect
    {
        public Action<Creature> Transform { get; }
    }
}