using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLinQ : MonoBehaviour
{

    public List<GameObject> gameObjectsToConsider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Execute method");

            GameObject objectNear = GetNearestGameObject(gameObjectsToConsider);
            Debug.Log("near Is " + objectNear.name);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Execute method with linq");

            var nearest = gameObjectsToConsider
             .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
             .FirstOrDefault();

            Debug.Log("near Is " + nearest.name);
        }

       

    }

    /// <summary>
    ///    Without linq Search 
    /// </summary>
    /// <param name="gameObjectsToConsider"></param>
    /// <returns></returns>
    private GameObject GetNearestGameObject(List<GameObject> gameObjectsToConsider)
    {
        float smallestDistance = Mathf.Infinity;
        GameObject nearestGameObject = new GameObject();
        foreach (var go in gameObjectsToConsider)
        {
            var distance = Vector3.Distance(transform.position, go.transform.position);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                nearestGameObject = go;
            }
        }
        return nearestGameObject;
    }
}
