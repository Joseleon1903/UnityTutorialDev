using UnityEngine;

public class PointOfInterest : Subject
{

    [SerializeField] private string poiName;

    private void OnTriggerEnter(Collider other)
    {
        Notify(poiName, ArchievementSystem.NotificationType.AchievementUnloked);

    }
}
