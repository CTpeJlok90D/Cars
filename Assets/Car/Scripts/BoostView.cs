using UnityEngine;

public class BoostView : MonoBehaviour
{
	[SerializeField] private SimpleCar _owner;
	[SerializeField] private GameObject _view;

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
	}

	private void OnBoostEnd()
	{
		_view.SetActive(false);
	}
}
