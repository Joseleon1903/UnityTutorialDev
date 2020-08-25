﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastIntoScene : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    private void OnValidate()
    {
        if (camera == null) {
            camera = Camera.main;
        }
    }

    private void Update()
    {
        Vector2 mouseScreenposition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mouseScreenposition);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            raycastHit.collider.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }




}
