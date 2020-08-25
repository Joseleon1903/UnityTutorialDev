using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLookingAtSphere : MonoBehaviour
{
    [SerializeField]
    private Color tintColor = Color.green;

    [SerializeField]
    private Color tintColorForRayCastAll = Color.yellow;

    [SerializeField]
    private bool multiple;

    [SerializeField]
    private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (multiple)
            RaycastMultiple();
        else
            RaycastSingle();
    }

    private void RaycastMultiple()
    {
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.forward;
        float maxDinstance = 2.5f;

        Debug.DrawRay(origin, direction * maxDinstance, Color.yellow);
        Ray ray = new Ray(origin, direction);
        var multipleHits = Physics.RaycastAll(ray, maxDinstance,layerMask);

        foreach (var rayCastHit in multipleHits) {
            rayCastHit.collider.GetComponent<Renderer>().material.color = tintColorForRayCastAll;
        }
    }

    private void RaycastSingle() {

        Vector3 origin = transform.position;
        Vector3 direction = Vector3.forward;

        float maxDinstance = 2.5f;

        Debug.DrawRay(origin, direction * maxDinstance, Color.green);

        Ray ray = new Ray(origin, direction);

        bool result = Physics.Raycast(ray , out RaycastHit hitinfo, maxDinstance, layerMask);

        if (result) 
        {
            hitinfo.collider.GetComponent<Renderer>().material.color = tintColor;
        }
    }
}
