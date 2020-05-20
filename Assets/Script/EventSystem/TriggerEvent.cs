using UnityEngine;

public class TriggerEvent : MonoBehaviour
{

    public int id;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter trigger;");

        GameEvent.current.DoorwayTriggerEnter(id);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit trigger;");

        GameEvent.current.DoorwayTriggerExit(id);

    }
}
