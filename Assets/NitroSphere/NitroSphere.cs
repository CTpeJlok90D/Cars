using System.Collections;
using UnityEngine;

public class NitroSphere : MonoBehaviour
{
	[SerializeField] private float _nitroValue = 50f;
	[SerializeField] private float _cooldown = 10f;
	[SerializeField] private MeshRenderer _renderer;

	private float _currentCooldown = 0;

	private void OnTriggerEnter(Collider other)
	{
		if (_currentCooldown > 0)
		{
			return;
		}
		if (other.gameObject.TryGetComponent(out SimpleCar car))
		{
			car.BoostFuel += _nitroValue;
			_currentCooldown = _cooldown;
		}
		StartCoroutine(CooldownCoroutine());
	}

	private IEnumerator CooldownCoroutine()
	{
		_renderer.enabled = false;
		while (_currentCooldown > 0)
		{
			yield return null;
			_currentCooldown -= Time.deltaTime;
		}
		_renderer.enabled = true;
	}
}
