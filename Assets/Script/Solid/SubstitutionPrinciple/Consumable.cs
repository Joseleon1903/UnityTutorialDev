using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{

    [SerializeField] private string usetext = "Drink Me!";

    public string UseText => usetext;

    public override void DisplayText()
    {
        Debug.Log($"{Name} : Press E To {UseText}");
    }
}
