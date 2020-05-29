using UnityEngine;
using System.Collections;

public class SceneControllerScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("Extension methods examples...");

        var cubeObject = GameObject.Find("Cube");

        var cylinder = GameObject.Find("Cylinder");

        float distance = cubeObject.transform.localPosition.DistanceFlat(cylinder.transform.position);

        Debug.Log($"DistanceFlat: {distance}");

    }

    
}
