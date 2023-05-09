using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockAllButton : MonoBehaviour
{
	[SerializeField] private Button _unlockAllButton;
	[SerializeField] private CarData[] _unlockedCars;
	private PlayerData PlayerData => PlayerDataContainer.Instance.Data;

	private void OnEnable()
	{
		_unlockAllButton.onClick.AddListener(UnlockAll);
	}

	private void OnDisable()
	{
		_unlockAllButton.onClick.RemoveListener(UnlockAll);
	}

	private void UnlockAll()
	{
		Debug.Log("Тут требуются внутриигровые покупки");

		foreach (CarData car in _unlockedCars)
		{
			List<int> colors = new(); 
			for (int i = 0; i < car.ColorPrices.Count; i++)
			{
				colors.Add(i);
			}

			PlayerData.AddUnlockedCar(car, colors);
		}
	}
}
