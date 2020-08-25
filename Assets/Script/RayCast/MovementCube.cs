using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{

    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpForce = 3f;

    [SerializeField] private float torque = 2f;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

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

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Jump Cube ");

            rigidbody.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Rotate rotate ");

            rigidbody.AddTorque(Vector3.up*torque, ForceMode.Impulse);
        }

    }
}
