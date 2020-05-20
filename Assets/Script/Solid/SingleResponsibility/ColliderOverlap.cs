using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ColliderOverlap : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger = new UnityEvent();

    private void OnCollisionEnter(Collision collision)
    {
        if (1 == collision.gameObject.layer)
        {
            onTrigger?.Invoke();
        }

    }

}
