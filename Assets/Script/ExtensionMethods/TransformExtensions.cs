using UnityEngine;
using System.Collections;

public static class TransformExtensions
{

    public static void LookAtY(this Transform transform, Vector3 point)
    {
        var lookPos = point - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }

}
