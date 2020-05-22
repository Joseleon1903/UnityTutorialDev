using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCube : MonoBehaviour
{

    [SerializeField] private float speed = 5f;

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        }.normalized;

        movement *= speed * Time.deltaTime;

        transform.Translate(movement);
        
    }
}
