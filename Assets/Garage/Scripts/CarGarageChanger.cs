using System.Collections.Generic;
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
	[SerializeField] private CarData[] _cars;

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
			_currentCarIndex = Mathf.Clamp(value, 0, _cars.Length - 1);
			_carGarageShower.CurrentCarData = CurrentCarData;
			PlayerDataContainer.Instance.CurrentCar = CurrentCarData;

			_selectButton.interactable = CurrentCarData.IsUnlocked;
			_lockObject.SetActive(CurrentCarData.IsUnlocked == false);

			_previousCarButton.interactable = _currentCarIndex != 0;
			_nextCarButton.interactable = _currentCarIndex != _cars.Length - 1;

			_carChanged.Invoke(_carGarageShower.CurrentCarInstance, CurrentCarData);
		}
	}

	protected void Awake()
	{
		_cars = Resources.LoadAll<CarData>("Cars");
		CurrentCarIndex = _currentCarIndex;
	}

	protected void OnEnable()
	{
		_nextCarButton?.onClick.AddListener(NextCar);
		_previousCarButton?.onClick.AddListener(PreviewCar);

		PlayerData.UnlockedCars.Changed += UnlockedCarsOnChanged;
	}

	protected void OnDisable()
	{
		_nextCarButton?.onClick.RemoveListener(NextCar);
		_previousCarButton?.onClick.RemoveListener(PreviewCar);

		if (PlayerDataContainer.HaveInstance)
		{
			PlayerData.UnlockedCars.Changed -= UnlockedCarsOnChanged;
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

	private void UnlockedCarsOnChanged(object sender, List<PlayerData.UnlockedStateCarInfo> newCarInfo)
	{
		CurrentCarIndex = _currentCarIndex;
	}
}