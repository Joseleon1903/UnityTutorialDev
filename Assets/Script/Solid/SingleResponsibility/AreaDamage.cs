using UnityEngine;
using System.Collections;

public class AreaDamage : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int damanageToDealToEachUnit = 10;

    public void Trigger()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var collider in colliders)
        {
            if (collider.GetComponent<Enemy>() != null)
            {
                collider.GetComponent<Enemy>().Damage(damanageToDealToEachUnit);
            }
        }
    }
}
