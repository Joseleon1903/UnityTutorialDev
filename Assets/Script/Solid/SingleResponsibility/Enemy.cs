using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    private int health = 100;

    internal void Damage(int damanageToDealToEachUnit)
    {
        health = Mathf.Max(0, health - damanageToDealToEachUnit);

        if (health == 0) {

            Destroy(gameObject);
        }

    }
}
