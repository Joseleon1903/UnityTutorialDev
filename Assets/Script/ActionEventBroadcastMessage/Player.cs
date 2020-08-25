using UnityEngine;
using System;

public class Player : MonoBehaviour
{

	//public delegate void PlayerTookDamageEvent(int hp);

	//public event PlayerTookDamageEvent OnPlayerTookDamage;

	public Action<int> OnPlayerTookDamage;

	public int HP { get; set; }

	private void Start()
	{
		HP = 10;
	}

	public void TakeDamage()
	{
		HP -= 1;
		if (OnPlayerTookDamage != null)
			OnPlayerTookDamage(HP);
	}

}
