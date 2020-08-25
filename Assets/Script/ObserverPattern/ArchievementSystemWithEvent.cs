using UnityEngine;
using System.Collections;

public class ArchievementSystemWithEvent : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteAll();

        PointOfInterestedWithEvent.OnPointInterestEntered += PointOfInterestedWithEvent_OnPointOfInterestEntered;

    }

    private void OnDestroy()
    {
        PointOfInterestedWithEvent.OnPointInterestEntered -= PointOfInterestedWithEvent_OnPointOfInterestEntered;
    }

    private void PointOfInterestedWithEvent_OnPointOfInterestEntered(PointOfInterestedWithEvent poi) {

        string achievementKey = "achievement " + poi.PoiName;

        if (PlayerPrefs.GetInt(achievementKey) == 1)
            return;

        PlayerPrefs.SetInt(achievementKey, 1);
        Debug.Log("Unloked " + poi.PoiName);
    }

}
