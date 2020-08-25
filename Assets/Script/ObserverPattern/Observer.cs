using System.Collections.Generic;
using UnityEngine;
using static ArchievementSystem;

public abstract class Observer : MonoBehaviour
{
    public abstract void OnNotify(object values, NotificationType notificationType);
}

public abstract class Subject : MonoBehaviour {

    private List<Observer> _observers = new List<Observer>();

    public void RegisterObserver(Observer observer) {
        _observers.Add(observer);
    }

    public void Notify(object values, NotificationType notificationType) {

        foreach (var observer in _observers)
            observer.OnNotify(values, notificationType);
    
    }


}
