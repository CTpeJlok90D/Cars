using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PlayerData
{
	public ReactiveVariable<int> Coins = new(0);
	public ReactiveVariable<int> Raiting = new(1000);
	[SerializeField] private ReactiveVariable<List<UnlockedStateCarInfo>> _unlockedCars = new(new() 
	{
		new UnlockedStateCarInfo()
		{
			Name = "Caravan",
			UnlockedColors = new(){0}
		}
	});

	public UnityEvent<List<UnlockedStateCarInfo>> UnlockedCarsChanged => _unlockedCars.Changed;

	public void AddUnlockedCar(CarData car, List<int> colors)
	{
		foreach (var carInfo in _unlockedCars.Value)
		{
			if (carInfo.Name == car.name)
			{
				carInfo.UnlockedColors.AddRange(colors);
				_unlockedCars.Changed.Invoke(_unlockedCars.Value);
				return;
			}
		}

		_unlockedCars.Value.Add(new()
		{
			Name = car.name, 
			UnlockedColors = colors
		});

		_unlockedCars.Changed.Invoke(_unlockedCars.Value);
	}

	public UnlockedStateCarInfo CarInfoByName(string name)
	{
		foreach (UnlockedStateCarInfo item in _unlockedCars.Value)
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
