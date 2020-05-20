using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargettingSystemScript : MonoBehaviour
{

    enum TargettingTypes
    { 
        All,
        Self,
        None,
        InRadius
    }

    
    [SerializeField]private TargettingTypes targettingType;
    [SerializeField] private float radius;


    private void Start()
    {
        var targets = GetTargets();
        foreach (Transform target in targets)
        {
            Debug.Log(target.name);
        }
    }

    public List<Transform> GetTargets()
    {
        var targets = new List<Transform>();

        switch (targettingType)
        {
            case TargettingTypes.Self:
                targets.Add(transform);
                break;

            case TargettingTypes.InRadius:
                Collider[] collidersInRadius = Physics.OverlapSphere(
                    transform.position,
                    radius
                );
                foreach (var collider in collidersInRadius)
                {
                    targets.Add(collider.transform);
                }
                break;

            case TargettingTypes.All:
                targets = FindObjectsOfType<Transform>().ToList();
                break;

            case TargettingTypes.None:
                Debug.LogWarning("Forgot to set a targetting type");
                break;
        }

        return targets;
    }
}
