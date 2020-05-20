using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class AllTargetting : MonoBehaviour, ITargetGetter
{
    public List<Transform> GetTargets(Transform transform)
    {
        return FindObjectsOfType<Transform>().ToList();
    }
}
