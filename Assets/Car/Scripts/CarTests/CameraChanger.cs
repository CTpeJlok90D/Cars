using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraChanger : MonoBehaviour
{
	[SerializeField] private List<CinemachineVirtualCamera> _camers;
	private Cartests _input;
	private int _currentCameraIndex = 0;

	public int CurrentCameraIndex
	{
		get
		{
			return _currentCameraIndex;
		}
		set
		{
			_currentCameraIndex = value;
			if (_currentCameraIndex >= _camers.Count)
			{
				_currentCameraIndex = 0;
			}
			if (_currentCameraIndex < 0)
			{
				_currentCameraIndex = _camers.Count - 1;
			}

			foreach (var camera in _camers)
			{
				camera.Priority = 0;
			}

			_camers[_currentCameraIndex].Priority = 1;
		}
	}

	private void Awake()
	{
		_input = new();
		_input.Enable();
	}

	private void OnEnable()
	{
		_input.Camera.Change.started += OnCameraChange;
		_input.Camera.Change.canceled += OnCameraChange;
	}

	private void OnDisable()
	{
		_input.Camera.Change.started -= OnCameraChange;
		_input.Camera.Change.canceled -= OnCameraChange;
	}

	private void OnCameraChange(InputAction.CallbackContext context)
	{
		int direction = Math.Sign(context.ReadValue<float>());

		CurrentCameraIndex += direction;
	}
}
