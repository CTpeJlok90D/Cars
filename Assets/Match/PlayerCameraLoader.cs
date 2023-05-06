using Cinemachine;
using UnityEngine;

public class PlayerCameraLoader : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera _camera;
	[SerializeField] private CarController _controller;

	private void Start()
	{
		_camera.Follow = _controller.Car.transform;
		_camera.LookAt = _controller.Car.transform;
	}
}
