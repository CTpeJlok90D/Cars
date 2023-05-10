using UnityEngine;

public class MobileInput : MonoBehaviour
{
	[SerializeField] private CarController _controller;
	[SerializeField] private HoldButton _nitroButton;
	[SerializeField] private HoldButton _breakButton;

	private void Start()
	{
		_nitroButton.Down.AddListener(_controller.Car.Boost);
		_breakButton.Down.AddListener(_controller.Car.Break);
		_nitroButton.Up.AddListener(_controller.Car.StopBoost);
		_breakButton.Up.AddListener(_controller.Car.StopBreak);
		if (SystemInfo.deviceType != DeviceType.Handheld)
		{
			gameObject.SetActive(false);
		}
	}

	private void OnDisable()
	{
		_nitroButton.Down.RemoveListener(_controller.Car.Boost);
		_breakButton.Down.RemoveListener(_controller.Car.Break);
		_nitroButton.Up.RemoveListener(_controller.Car.StopBoost);
		_breakButton.Up.RemoveListener(_controller.Car.StopBreak);
	}
}
