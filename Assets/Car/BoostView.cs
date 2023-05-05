using Cinemachine;
using UnityEngine;

public class BoostView : MonoBehaviour
{
	[SerializeField] private SimpleCar _owner;
	[SerializeField] private GameObject _view;
	[SerializeField] private CinemachineVirtualCamera _boostCamera;
	[SerializeField] private int _boostCameraPryority = 15;

	protected void OnEnable()
	{
		_owner.Boosted.AddListener(OnBoostBegin);
		_owner.StoppedBoost.AddListener(OnBoostEnd);
	}

	private void OnDisable()
	{
		_owner.Boosted.RemoveListener(OnBoostBegin);
		_owner.StoppedBoost.RemoveListener(OnBoostEnd);
	}

	private void OnBoostBegin()
	{
		_view.SetActive(_owner.CanBoost);
		if (_boostCamera == null || _owner.CanBoost == false)
		{
			return;
		}
		_boostCamera.Priority = _boostCameraPryority;
	}

	private void OnBoostEnd()
	{
		_view.SetActive(false);
		if (_boostCamera == null)
		{
			return;
		}
		_boostCamera.Priority = 0;
	}
}
