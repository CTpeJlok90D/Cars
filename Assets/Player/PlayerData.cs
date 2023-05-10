using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PlayerData
{
	public ReactiveVariable<int> Coins = new(0);
	public ReactiveVariable<int> Raiting = new(1000);
	public int WinCount = 0;
	[SerializeField] private List<UnlockedStateCarInfo> _unlockedCars = new() 
	{
		new UnlockedStateCarInfo()
		{
			Name = "Caravan",
			UnlockedColors = new(){0}
		}
	};
	private UnityEvent<List<UnlockedStateCarInfo>> _unlockedCardsChanged = new();

	public UnityEvent<List<UnlockedStateCarInfo>> UnlockedCarsChanged => _unlockedCardsChanged;

	public void AddUnlockedCar(CarData car, List<int> colors)
	{
		foreach (var carInfo in _unlockedCars)
		{
			if (carInfo.Name == car.name)
			{
				carInfo.UnlockedColors.AddRange(colors);
				_unlockedCardsChanged.Invoke(_unlockedCars);
				return;
			}
		}

		_unlockedCars.Add(new()
		{
			Name = car.name, 
			UnlockedColors = colors
		});

		_unlockedCardsChanged.Invoke(_unlockedCars);
	}

	public UnlockedStateCarInfo CarInfoByName(string name)
	{
		foreach (UnlockedStateCarInfo item in _unlockedCars)
		{
			if (item.Name == name)
			{
				return item;
			}
		}

		return null;
	}

	[Serializable]
	public class UnlockedStateCarInfo
	{
		public string Name;
		public List<int> UnlockedColors;
	}
}
