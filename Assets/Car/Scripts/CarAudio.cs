using UnityEngine;

public class CarAudio : MonoBehaviour
{
	[SerializeField] private SimpleCar _car;
	[SerializeField] private float _normalSpeed = 60;
	[SerializeField] private float _defualtPitch = 0.7f;
	[SerializeField] private float _maxPitch = 1.5f;
	[SerializeField] private float _minPitch = 0.7f;
	[SerializeField] private AudioSource _aidioSource;

	private void Update()
	{
		_aidioSource.pitch = Mathf.Clamp(_defualtPitch + Mathf.Clamp(_car.Speed / _normalSpeed,-1,1), _minPitch, _maxPitch);
	}
}
