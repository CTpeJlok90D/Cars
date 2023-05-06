using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
	public ReactiveVariable<int> Coins = new(200);
	public ReactiveVariable<List<UnlockedStateCarInfo>> UnlockedCars = new(new() 
	{
		new UnlockedStateCarInfo()
		{
			Name = "Caravan",
			UnlockedColors = new(){0}
		}
	});
	public ReactiveVariable<int> Raiting = new(0);

	public UnlockedStateCarInfo CarInfoByName(string name)
	{
		foreach (UnlockedStateCarInfo item in UnlockedCars.Value)
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
