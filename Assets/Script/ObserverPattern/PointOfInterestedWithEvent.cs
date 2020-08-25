using UnityEngine;
using System.Collections;
using System;

public class PointOfInterestedWithEvent : MonoBehaviour
{
    public static event Action<PointOfInterestedWithEvent> OnPointInterestEntered;

    [SerializeField] private string _poiName;
    
    public string PoiName { get { return _poiName; } }

    private void OnTriggerEnter(Collider other)
    {
        if (OnPointInterestEntered != null) {
            OnPointInterestEntered(this);
        }
        
    }
}
