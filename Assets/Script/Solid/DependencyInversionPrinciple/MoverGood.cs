using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverGood : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private IMovementImputGetter moverImputGetter = null;

    private void Awake()
    {
        moverImputGetter = GetComponent<IMovementImputGetter>();
    }


    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3
        {
            x = moverImputGetter.Horizontal,
            y = 0f,
            z = moverImputGetter.Vertical
        }.normalized;

        movement *= speed * Time.deltaTime;

        transform.Translate(movement);

    }
}
