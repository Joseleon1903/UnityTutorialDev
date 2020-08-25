using UnityEngine;

public class BlasterShootGenericPooled : MonoBehaviour
{
    public float moveSpeed = 5f;

    private float lifeTime;

    private float maxLifeTime = 5;

    private void OnEnable()
    {
        lifeTime = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime) {
            ShootPool.Instance.ReturnToPool(this);
        }
    }
}
