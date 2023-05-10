using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NitroView : MonoBehaviour
{
	[SerializeField] private Image _imageView;
	[SerializeField] private CarController _carController;
	[SerializeField] private TMP_Text _text;
	[SerializeField] private float _maxDgree = 0.692f;

	private void Start()
	{
		_carController.Car.BoostAmoutChanged.AddListener(OnAmoutChange);
	}

	private void OnDisable()
	{
		_carController.Car.BoostAmoutChanged.RemoveListener(OnAmoutChange);
	}

	private void OnAmoutChange(float newValue, float maxValue)
	{
		_imageView.fillAmount = Mathf.Lerp(0, _maxDgree, newValue / maxValue);
		_text.text = ((int)newValue).ToString();
	}
}
