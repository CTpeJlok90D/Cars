using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCar : CarController
{
	private InputMap InputMap => InputSingletone.Instance;
	protected void OnEnable()
	{
		InputMap.Car.Gas.started += OnGas;
		InputMap.Car.Gas.performed += OnGas;
		InputMap.Car.Gas.canceled += OnGas;

		InputMap.Car.Rotate.started += OnStreeng;
		InputMap.Car.Rotate.performed += OnStreeng;
		InputMap.Car.Rotate.canceled += OnStreeng;

		InputMap.Car.Boost.started += OnBoost;
		InputMap.Car.Boost.canceled += OnBoost;

		InputMap.Car.Break.started += OnBreak;
	}

	protected void OnDisable()
	{
		InputMap.Car.Gas.started -= OnGas;
		InputMap.Car.Gas.performed -= OnGas;
		InputMap.Car.Gas.canceled -= OnGas;

		InputMap.Car.Rotate.started -= OnStreeng;
		InputMap.Car.Rotate.performed -= OnStreeng;
		InputMap.Car.Rotate.canceled -= OnStreeng;

		InputMap.Car.Boost.started -= OnBoost;
		InputMap.Car.Boost.canceled -= OnBoost;

		InputMap.Car.Break.started -= OnBreak;
	}

	private void OnBreak(InputAction.CallbackContext obj)
	{
		Car.Break();
	}

	private void OnGas(InputAction.CallbackContext context)
	{
		float contextValue = context.ReadValue<float>();
		Car.CurrentMotoringInput = contextValue;
	}

	private void OnStreeng(InputAction.CallbackContext context)
	{
		float contextValue = context.ReadValue<float>();
		Car.CurrentSteeringInput = contextValue;
	}

	private void OnBoost(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Car.Boost();
		}
		if (context.canceled)
		{
			Car.StopBoost();
		}
	}
}
