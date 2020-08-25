using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleFactory
{


    public abstract class Ability
    {
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override void Process()
        {
            // do some fire creation
            Debug.Log("Creation Fire ");

        }
    }

    public class HealSelfAbility : Ability
    {
        public override void Process()
        {
            // self health in crement 
            Debug.Log("Health Up ");
        }
    }

    public class AbilityFactory
    {

        public Ability GetAbility(string abilityType) {

            switch (abilityType) {

                case "fire": 
                    return new StartFireAbility();

                case "health": 
                    return new HealSelfAbility();

                default: return null;
            }
        }


    }


}
