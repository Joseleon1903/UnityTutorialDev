using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{

    [SerializeField] private new string name = "New Item name";

    [SerializeField] private string description = "new item Description";

    public string Name => name;

    public string Description => description;

    public abstract void DisplayText();
}
