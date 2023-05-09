using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitSound : MonoBehaviour
{
	[SerializeField] private List<AudioClip> _hitClips;
	[SerializeField] private AudioSource _source;
	private void OnCollisionEnter(Collision collision)
	{
		_source.clip = _hitClips[Random.Range(0, _hitClips.Count)];
		_source.Play();
	}
}
