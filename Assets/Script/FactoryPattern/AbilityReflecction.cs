using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

namespace ReflectionFacotry
{

    public abstract class Ability
    {
        public abstract string Name { get; }

        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override string Name => "Fire";

        public override void Process()
        {
            // do some fire creation
            Debug.Log("Creation Fire ");

        }
    }

    public class HealSelfAbility : Ability
    {
        public override string Name => "Health";

        public override void Process()
        {
            // self health in crement 
            Debug.Log("Health Up ");
        }
    }


    public class AbilityFactory
    {

        private static  Dictionary<string, Type> abilitiesName;

        private static bool IsInitialized => abilitiesName != null;

        private static void InitializedFactory() {

            if (IsInitialized) {

                return;
            }

            var abilitiTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes().
                Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Ability)));

            abilitiesName = new Dictionary<string, Type>();


            foreach (var type in abilitiTypes) {
                var temEffect = Activator.CreateInstance(type) as Ability;

                abilitiesName.Add(temEffect.Name, type);
            }
        }


        public static Ability GetAbility(string abilityType) {

            InitializedFactory();

            if (abilitiesName.ContainsKey(abilityType)) {

                Type type = abilitiesName[abilityType];
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }
            return null;
        }

        internal IEnumerable<string> GeAbilityNames() {
            return abilitiesName.Keys;
        }

    }
}