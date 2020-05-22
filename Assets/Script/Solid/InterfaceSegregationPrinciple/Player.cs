using UnityEngine;
using System.Collections;

namespace SOLID.ImterfaceSegregation
{
    public class Player : IManaUser
    {
        public int Mana => throw new System.NotImplementedException();

        public int MaxMana => throw new System.NotImplementedException();

        public void SpendMana(int manaToSpend)
        {
            throw new System.NotImplementedException();
        }
    }
}