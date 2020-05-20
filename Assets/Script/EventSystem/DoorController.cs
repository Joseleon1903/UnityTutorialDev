using UnityEngine;

public class DoorController : MonoBehaviour
{

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.onDoorwayTriggerEnter += OnDoorWayOpen;
        GameEvent.current.onDoorwayTriggerExit += OnDoorWayClose;
    }


    private void OnDoorWayOpen(int id) {
        Debug.Log("open door methos executed ");
        if (id == this.id) {
            LeanTween.moveLocalY(gameObject, 9.25f, 1f).setEaseOutQuad();
        }
    }

    private void OnDoorWayClose(int id)
    {
        Debug.Log("close door methos executed ");
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 6.95f, 1f).setEaseOutQuad();

        }
    }

    private void OnDestroy()
    {
        GameEvent.current.onDoorwayTriggerEnter -= OnDoorWayOpen;
        GameEvent.current.onDoorwayTriggerExit -= OnDoorWayClose;
    }


}
