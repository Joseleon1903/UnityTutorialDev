using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{

	private Text _text;

	private void Awake()
	{
		_text = GetComponent<Text>();
		Player _player = FindObjectOfType<Player>();
		_player.OnPlayerTookDamage += HandlePlayerTookDamage;
	}

	private void HandlePlayerTookDamage(int hp)
	{
		_text.text = hp.ToString();
	}

}
