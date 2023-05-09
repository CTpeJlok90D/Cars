using UnityEngine;

public class CarAutoPilot : MonoBehaviour
{
	[SerializeField] private SimpleCar _car;
	[Range(-1,1)]
	[SerializeField] private float _motorInputValue = 0f;
	[Range(-1, 1)]
	[SerializeField] private float _streengInputValue = 0f;
	[SerializeField] private bool _useNitro = false;

	private void Update()
	{
		_car.CurrentMotoringInput = _motorInputValue;
		_car.CurrentSteeringInput = _streengInputValue;
		if (_useNitro)
		{
			_car.Boost();
		}
		else
		{
			_car.StopBoost();
		}
	}
}
