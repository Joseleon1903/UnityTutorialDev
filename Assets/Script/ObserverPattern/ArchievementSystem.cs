using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

public class ArchievementSystem : Observer
{
  

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteAll();

        foreach (var poi in FindObjectsOfType<PointOfInterest>()) {
            poi.RegisterObserver(this);
        
        }
    }

    public override void OnNotify(object values, NotificationType notificationType)
    {
        if (notificationType == NotificationType.AchievementUnloked)
        {

            string achievementKey = "achievement " + values;

            if (PlayerPrefs.GetInt(achievementKey) == 1)
                return;

            PlayerPrefs.SetInt(achievementKey, 1);
            Debug.Log("Unloked " + values);
        }

    }

    public enum NotificationType {
        AchievementUnloked
    }

}
