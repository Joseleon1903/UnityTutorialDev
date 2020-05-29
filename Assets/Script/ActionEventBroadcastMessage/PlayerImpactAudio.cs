using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerImpactAudio : MonoBehaviour
{
	
	private AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();

		FindObjectOfType<Player>().OnPlayerTookDamage += PlayAudioOnPlayerTookDamage;
	}

	private void PlayAudioOnPlayerTookDamage(int hp)
	{
	_audioSource.Play();
	}
}
