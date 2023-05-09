using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CarGarageChanger : MonoBehaviour
{
	[SerializeField] private Button _nextCarButton;
	[SerializeField] private Button _previousCarButton;
	[SerializeField] private CarShower _carGarageShower;
	[SerializeField] private Button _selectButton;
	[SerializeField] private GameObject _lockObject;
	[SerializeField] private UnityEvent<SimpleCar, CarData> _carChanged;
	[SerializeField] private List<CarData> _cars;

	private int _currentCarIndex = 0;
	public CarData CurrentCarData => _cars[CurrentCarIndex];
	public UnityEvent<SimpleCar, CarData> CarChanged => _carChanged;
	public CarShower CarShower => _carGarageShower;
	public PlayerData PlayerData => PlayerDataContainer.Instance.Data;

	public int CurrentCarIndex
	{
		get
		{
			return _currentCarIndex;
		}
		set
		{
			_currentCarIndex = Mathf.Clamp(value, 0, _cars.Count - 1);
			_carGarageShower.CurrentCarData = CurrentCarData;
			PlayerDataContainer.Instance.CurrentCar = CurrentCarData;

			_selectButton.enabled = CurrentCarData.IsUnlocked;
			_lockObject.SetActive(CurrentCarData.IsUnlocked == false);

			_previousCarButton.interactable = _currentCarIndex != 0;
			_nextCarButton.interactable = _currentCarIndex != _cars.Count - 1;

			_carChanged.Invoke(_carGarageShower.CurrentCarInstance, CurrentCarData);
		}
	}

	protected void Awake()
	{
		_cars = Resources.LoadAll<CarData>("Cars").ToList();
	}

	private void Start()
	{
		CurrentCarIndex = _currentCarIndex;
	}

	protected void OnEnable()
	{
		_nextCarButton?.onClick.AddListener(NextCar);
		_previousCarButton?.onClick.AddListener(PreviewCar);

		PlayerData.UnlockedCarsChanged.AddListener(UnlockedCarsOnChanged);
	}

	protected void OnDisable()
	{
		_nextCarButton?.onClick.RemoveListener(NextCar);
		_previousCarButton?.onClick.RemoveListener(PreviewCar);

		if (PlayerDataContainer.HaveInstance)
		{
			PlayerData.UnlockedCarsChanged.RemoveListener(UnlockedCarsOnChanged);
		}
	}

	private void PreviewCar()
	{
		CurrentCarIndex--;
	}

	private void NextCar()
	{
		CurrentCarIndex++;
	}

	private void UnlockedCarsOnChanged(List<PlayerData.UnlockedStateCarInfo> newCarInfo)
	{
		CurrentCarIndex = _currentCarIndex;
	}
}