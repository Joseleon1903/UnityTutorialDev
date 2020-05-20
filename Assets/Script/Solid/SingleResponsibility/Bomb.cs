using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField]private float secondsutilDetonation = 3f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int damanageToDealToEachUnit = 10;

    private LayerMask explodeOnContactlayermask = new LayerMask();


    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (1 == other.gameObject.layer) {
            Detonate();
        }
    }

    private void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var collider in colliders ) {
            if (collider.GetComponent<Enemy>() != null) {
                collider.GetComponent<Enemy>().Damage(damanageToDealToEachUnit);
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator Timer() {

        yield return new WaitForSeconds(secondsutilDetonation);
        Detonate();
    }

}
