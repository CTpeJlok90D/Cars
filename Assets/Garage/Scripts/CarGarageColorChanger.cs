using System.Collections.Generic;
using UnityEngine;

public class CarGarageColorChanger : MonoBehaviour
{
	[SerializeField] private CarGarageChanger _carGarageChanger;
	[SerializeField] private ColorSelectButton _colorViewPrefab;
	[SerializeField] private Transform _colorsButtonParent;

	private CarCustomizer _customizer;
	
	protected void OnEnable()
	{
		_carGarageChanger.CarChanged.AddListener(OnCurrentCarChange);
		PlayerDataContainer.Instance.Data.UnlockedCars.Changed += UnlockedCarsOnChanged;
	}

	protected void OnDisable()
	{
		_carGarageChanger.CarChanged.RemoveListener(OnCurrentCarChange);
		if (PlayerDataContainer.HaveInstance)
		{
			PlayerDataContainer.Instance.Data.UnlockedCars.Changed -= UnlockedCarsOnChanged;
		}
	}

	private void Start()
	{
		OnCurrentCarChange(_carGarageChanger.CarShower.CurrentCarInstance, _carGarageChanger.CurrentCarData);
	}

	private void UnlockedCarsOnChanged(object sender, List<PlayerData.UnlockedStateCarInfo> e)
	{
		OnCurrentCarChange(_carGarageChanger.CarShower.CurrentCarInstance, _carGarageChanger.CurrentCarData);
	}

	private void OnCurrentCarChange(SimpleCar newCar, CarData data)
	{
		_customizer = newCar.Customizer;
		foreach (Transform obj in _colorsButtonParent)
		{
			Destroy(obj.gameObject);
		}
		List<CarData.ColorInfo> colors = data.ColorPrices;
		int i = 0;
		foreach (CarData.ColorInfo colorInfo in colors)
		{
			Instantiate(_colorViewPrefab, _colorsButtonParent).Init(colorInfo.Color, _customizer, colorInfo.Price, data.name, i);
			i++;
		}
	}
}
