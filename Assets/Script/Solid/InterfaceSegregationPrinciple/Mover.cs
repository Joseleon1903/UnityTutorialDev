using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID.ImterfaceSegregation
{
    public class Mover : MonoBehaviour
    {
        public void Move(Transform target, Vector3 movement)
        {
            var moveable = target.GetComponent<IMoveable>();

            if (moveable == null) { return; }

            moveable.Move(movement);

            Debug.Log(moveable.Position);
        }
    }
}