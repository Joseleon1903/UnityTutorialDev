using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Transform transform;

    private float speed = 0.1f;

    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("PLayer press key W");
            float posZ = transform.localPosition.z;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, posZ += speed);
        
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("PLayer press key S");
            float posZ = transform.localPosition.z;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, posZ -= speed);

        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("PLayer press key A");
            float posX = transform.localPosition.x;
            transform.localPosition = new Vector3( posX+=speed, transform.localPosition.y, transform.localPosition.z);

        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("PLayer press key D");
            float posX = transform.localPosition.x;
            transform.localPosition = new Vector3(posX -= speed, transform.localPosition.y, transform.localPosition.z);

        }


    }
}
