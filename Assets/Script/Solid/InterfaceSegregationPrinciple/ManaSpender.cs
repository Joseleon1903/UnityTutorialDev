using UnityEngine;

namespace SOLID.ImterfaceSegregation
{
    public class ManaSpender : MonoBehaviour
    {
        public void CastSpell(Transform caster, int manaCost)
        {
            var manaUser = caster.GetComponent<IManaUser>();

            if (manaUser == null) { return; }

            manaUser.SpendMana(manaCost);

            Debug.Log(manaUser.Mana);
        }
    }
}