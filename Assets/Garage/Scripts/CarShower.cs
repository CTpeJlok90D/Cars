using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarShower : MonoBehaviour
{
	[SerializeField] private GameObject _carParent;
	[SerializeField] private TMP_Text _carNameField;
	[SerializeField] private Slider _speedSlider;
	[SerializeField] private Slider _nitroSlider;
	[SerializeField] private Slider _breakSlider;
	[SerializeField] private bool _disablePhysics = true;
	[SerializeField] private bool _disableSound = true;
	[Range(-1,1)]
	[SerializeField] private float _carWheelRotate = 0;
	
	private SimpleCar _currentCarInstance;

	private CarData _currentCarData;
	public SimpleCar CurrentCarInstance => _currentCarInstance;
	public CarCustomizer CarCusomizer => CurrentCarInstance.Customizer;
	public CarData CurrentCarData
	{
		get
		{
			return _currentCarData;
		}
		set
		{
			if (_currentCarInstance != null)
			{
				Destroy(_currentCarInstance.gameObject);
			}
			if (value != null)
			{
				_currentCarData = value;
				_currentCarInstance = Instantiate(value.ViewPrefab, _carParent.transform.position, _carParent.transform.rotation);
				_currentCarInstance.transform.parent = _carParent.transform;
				_currentCarInstance.Rigidbody.isKinematic = _disablePhysics;
				_currentCarInstance.CurrentSteeringInput = _carWheelRotate;
				if (_carNameField != null) _carNameField.text = value.ViewName;
				if (_speedSlider != null) _speedSlider.value = value.Speed;
				if (_nitroSlider != null) _nitroSlider.value = value.Nitro;
				if (_breakSlider != null) _breakSlider.value = value.Break;
				_currentCarInstance.AudioSource.enabled = _disableSound == false;
			}
		}
	}
}