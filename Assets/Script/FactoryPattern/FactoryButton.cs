using ReflectionFacotry;
using UnityEngine;

public class FactoryButton : MonoBehaviour
{
    [SerializeField] private string abilityName;

    public void OnClickFactoryButton() {

        var ability = AbilityFactory.GetAbility(abilityName);
        ability.Process();

    }

}
