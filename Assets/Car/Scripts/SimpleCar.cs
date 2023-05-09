using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class SimpleCar : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private AudioSource _source;
	[SerializeField] private List<AxleInfo> _axleInfos;
	[SerializeField] private float _maxMotorTorque = 400;
	[SerializeField] private float _maxStreeringAngle = 30;
	[SerializeField] private float _streeringAnglePerSecondMultyply = 5;
	[SerializeField] private float _handbrakePower = 0.8f;
	[Header("Boost")]
	[SerializeField] private float _startBoostFuelRequest = 15f;
	[SerializeField] private float _boostPower = 100;
	[SerializeField] private float _boostMaxMotorTorque = 800;
	[SerializeField] private float _boostFuel = 0;
	[SerializeField] private float _maxBoostFuel = 100;
	[SerializeField] private float _boostFuelExpenditurePerSecond = 50;
	[SerializeField] private UnityEvent<float, float> _boostAmoutChanged = new();

	[SerializeField] private CarCustomizer _customizer;

	private float _currentTargetStringInput;
	private float _currentStringInput;
	private float _currentMotoringInput;

	private UnityEvent _boosted = new();
	private UnityEvent _stoppedBoost = new();

	private bool _handbrake = false;
	private bool _boosting = false;

	public bool Disabled = false;

	private Coroutine _boostCoroutine;

	public CarCustomizer Customizer => _customizer;
	public List<AxleInfo> AxleInfos => _axleInfos;
	public Rigidbody Rigidbody => _rigidbody;
	public bool CanBoost => BoostFuel > 0;
	public UnityEvent Boosted => _boosted;
	public UnityEvent StoppedBoost => _stoppedBoost;
	public UnityEvent<float, float> BoostAmoutChanged => _boostAmoutChanged;
	public bool Boosting => _boosting;
	public float Speed => _rigidbody.velocity.magnitude * 3.6f;
	public AudioSource AudioSource => _source;

	public float BoostFuel
	{
		get
		{
			return _boostFuel;
		}
		set
		{
			_boostFuel = Mathf.Clamp(value, 0, _maxBoostFuel);
			BoostAmoutChanged.Invoke(_boostFuel, _maxBoostFuel);

			if (_boostFuel == 0)
			{
				StopBoost();
			}
		}
	}

	public float CurrentSteeringInput
	{
		get => _currentTargetStringInput;
		set
		{
			_handbrake = false;
			_currentTargetStringInput = Mathf.Clamp(value, -1, 1);
		}
	}
	public float CurrentMotoringInput
	{
		get =>_currentMotoringInput;
		set
		{
			_handbrake = false;
			_currentMotoringInput = Mathf.Clamp(value, -1, 1);
		}
	}

	public void Boost()
	{
		if (_boosting == true || _boostFuel < _startBoostFuelRequest)
		{
			return;
		}
		_boostFuel -= _startBoostFuelRequest;
		_rigidbody.AddForce(_rigidbody.transform.forward * _rigidbody.mass * _boostPower);
		_boosting = true;
		_boostCoroutine = StartCoroutine(BoostCorutine());
		_boosted.Invoke();
	}

	public void StopBoost()
	{
		_boosting = false;
		_stoppedBoost.Invoke();
	}

	private IEnumerator BoostCorutine()
	{
		while (_boosting)
		{
			BoostFuel -= _boostFuelExpenditurePerSecond * Time.deltaTime;
			yield return null;
		}
		StopBoost();
	}
	public void Break()
	{
		_handbrake = true;
	}

	public void StopBreak()
	{
		_handbrake = false;
	}

	protected void FixedUpdate()
	{
		if (Disabled)
		{
			StopCar();
		}
		if (_handbrake && _axleInfos[0].LeftWheel.isGrounded)
		{
			_rigidbody.velocity = _rigidbody.velocity * _handbrakePower;
			foreach (AxleInfo axleInfo in _axleInfos)
			{
				if (axleInfo.Motor)
				{
					axleInfo.LeftWheel.rotationSpeed = 0;
					axleInfo.RightWheel.rotationSpeed = 0;
				}
			}
			return;
		}
		UpdateSteeringInput();
		ApplyInputs();
	}

	private void StopCar()
	{
		_currentMotoringInput = 0;
		_currentStringInput = 0;

		foreach (AxleInfo axleInfo in _axleInfos)
		{
			axleInfo.LeftWheel.rotationSpeed = 0;
			axleInfo.RightWheel.rotationSpeed = 0;
		}
	}

	private void ApplyInputs()
	{
		float maxMotorTorque = _boosting ? _boostMaxMotorTorque : _maxMotorTorque;
		foreach (AxleInfo axleInfo in _axleInfos)
		{
			if (axleInfo.Steering)
			{
				axleInfo.LeftWheel.steerAngle = _currentStringInput * _maxStreeringAngle;
				axleInfo.RightWheel.steerAngle = _currentStringInput * _maxStreeringAngle;
			}
			if (axleInfo.Motor)
			{
				axleInfo.LeftWheel.motorTorque = CurrentMotoringInput * maxMotorTorque;
				axleInfo.RightWheel.motorTorque = CurrentMotoringInput * maxMotorTorque;
			}

			ApplyWheelPosition(axleInfo.LeftWheel, axleInfo.LeftWheelView);
			ApplyWheelPosition(axleInfo.RightWheel, axleInfo.RightWheelView);
		}
	}

	private void UpdateSteeringInput()
	{
		_currentStringInput = Mathf.MoveTowards(_currentStringInput, _currentTargetStringInput, Time.deltaTime * _streeringAnglePerSecondMultyply);
	}

	private void ApplyWheelPosition(WheelCollider wheelColider, Transform view)
	{
		Vector3 position;
		Quaternion rotation;
		wheelColider.GetWorldPose(out position, out rotation);

		view.position = position;
		view.rotation = rotation;
	}

	[Serializable]
	public struct AxleInfo
	{
		[SerializeField] private WheelCollider _leftWheel;
		[SerializeField] private Transform _leftWheelView;
		[SerializeField] private WheelCollider _rightWheel;
		[SerializeField] private Transform _rightWheelView;
		[SerializeField] private bool _motor;
		[SerializeField] private bool _steering;

		public WheelCollider LeftWheel => _leftWheel;
		public Transform LeftWheelView => _leftWheelView;
		public WheelCollider RightWheel => _rightWheel;
		public Transform RightWheelView => _rightWheelView;
		public bool Steering => _steering;
		public bool Motor => _motor;
	}

#if UNITY_EDITOR
	private void OnDrawGizmosSelected()
	{
		Vector3 moveDirection = transform.position + transform.TransformDirection(new Vector3(0,0,_currentMotoringInput));
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, moveDirection);

		Vector3 streengDirection = transform.position + transform.TransformDirection(new Vector3(_currentStringInput, 0, 0));
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine(transform.position,  streengDirection);
	}
#endif
}
