using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCar : SimpleCar
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
	}

	private void OnGas(InputAction.CallbackContext context)
	{
		float contextValue = context.ReadValue<float>();
		CurrentMotoringInput = contextValue;
	}

	private void OnStreeng(InputAction.CallbackContext context)
	{
		float contextValue = context.ReadValue<float>();
		CurrentSteeringInput = contextValue;
	}

	private void OnBoost(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Boost();
		}
		if (context.canceled)
		{
			StopBoost();
		}
	}
}
