using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class Creature
    {
        // List<IEffect> effects;
        // string name;
        // int health = 0;
        // int maxHealth = 0;

        // // TODO: Factory to init from SO/Json
        // public Creature(string name)
        // {
        //     this.name = name;
        // }

        public void ApplyEffect(IEffect effect)
        {
            effect.Transform(this);
        }
    }
}
