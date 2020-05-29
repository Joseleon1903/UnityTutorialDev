using UnityEngine;
using System.Collections;

public class PlayerDamager : MonoBehaviour
{

	private void Start()
	{
		StartCoroutine(DealDamageEvery5Seconds());
	}

	private IEnumerator DealDamageEvery5Seconds()
	{
		while (true)
		{
			FindObjectOfType<Player>().TakeDamage();
			yield return new WaitForSeconds(2f);
		}
	}
}
