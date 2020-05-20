using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TriggerOverlap : MonoBehaviour
{
    [SerializeField]private UnityEvent onTrigger = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (1 == other.gameObject.layer)
        {
            onTrigger?.Invoke();
        }
    }
}
