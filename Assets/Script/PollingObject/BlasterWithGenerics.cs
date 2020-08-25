using UnityEngine;

public class BlasterWithGenerics : MonoBehaviour
{
    [SerializeField] private float refireRate = 2f;

    private float fireTimer;


    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= refireRate) {

            fireTimer = 0;
            Fire();
        
        }

    }

    private void Fire()
    {
        var shoot = ShootPool.Instance.Get();
        shoot.transform.rotation = transform.rotation;
        shoot.transform.position = transform.position;
        shoot.gameObject.SetActive(true);

    }
}
