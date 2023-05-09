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
		PlayerDataContainer.Instance.Data.UnlockedCarsChanged.AddListener(UnlockedCarsOnChanged);
	}

	protected void OnDisable()
	{
		_carGarageChanger.CarChanged.RemoveListener(OnCurrentCarChange);
		if (PlayerDataContainer.HaveInstance)
		{
			PlayerDataContainer.Instance.Data.UnlockedCarsChanged.RemoveListener(UnlockedCarsOnChanged);
		}
	}

	private void Start()
	{
		OnCurrentCarChange(_carGarageChanger.CarShower.CurrentCarInstance, _carGarageChanger.CurrentCarData);
	}

	private void UnlockedCarsOnChanged(List<PlayerData.UnlockedStateCarInfo> e)
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
			Instantiate(_colorViewPrefab, _colorsButtonParent).Init(data, colorInfo, _customizer, i);
			i++;
		}
		_customizer.Color = data.ColorPrices[0].Color;
		PlayerDataContainer.Instance.CarColor = data.ColorPrices[0].Color;
	}
}
