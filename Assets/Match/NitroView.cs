using UnityEngine;
using UnityEngine.UI;

public class NitroView : MonoBehaviour
{
	[SerializeField] private Image _imageView;
	[SerializeField] private SimpleCar _car;

	private void OnEnable()
	{
		_car.BoostAmoutChanged.AddListener(OnAmoutChange);
	}

	private void OnAmoutChange(float newValue, float maxValue)
	{
		_imageView.fillAmount = newValue / maxValue;
	}
}
