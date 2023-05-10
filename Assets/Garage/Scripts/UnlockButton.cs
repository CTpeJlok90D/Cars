using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
	[SerializeField] private Button _unlockAllButton;
	[SerializeField] private UnlockCarDataInfo[] _unlockedCars;
	[SerializeField] private int _additionalCoins = 0;
	[SerializeField] private string _unlockedText = "Unlocked";
	[SerializeField] private TMP_Text _text;
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

		foreach (UnlockCarDataInfo carInfo in _unlockedCars)
		{
			PlayerData.AddUnlockedCar(carInfo.CarData, carInfo.Colors);
		}

		_unlockAllButton.interactable = false;
		PlayerData.Coins.Value += _additionalCoins;
		if (_text != null)
		{
			_text.text = _unlockedText;
		}
	}

	[Serializable]
	private class UnlockCarDataInfo
	{
		[SerializeField] private CarData _carData;
		[SerializeField] private List<int> _colors;

		public CarData CarData => _carData;
		public List<int> Colors => _colors;
	}
}
