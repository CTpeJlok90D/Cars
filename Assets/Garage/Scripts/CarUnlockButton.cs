using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarUnlockButton : MonoBehaviour
{
	[SerializeField] private Button _unlockButton;
	[SerializeField] private CarGarageChanger _carChager;
	[SerializeField] private TMP_Text _priceCaption;
	[SerializeField] private string _valute = "$";
	[SerializeField] private string _realValute = "p";

	private CarData _carData;

	public PlayerData PlayerData => PlayerDataContainer.Instance.Data;
	private void OnEnable()
	{
		_carChager.CarChanged.AddListener(OnCarChanged);
		_unlockButton.onClick.AddListener(OnUnlockClick);
	}

	private void OnDisable()
	{
		_carChager.CarChanged.RemoveListener(OnCarChanged);
		_unlockButton.onClick.RemoveListener(OnUnlockClick);
	}

	private void OnCarChanged(SimpleCar carInstance, CarData carData)
	{
		_unlockButton.gameObject.SetActive(carData.IsUnlocked == false);
		_priceCaption.gameObject.SetActive(carData.IsUnlocked == false);

		_carData = carData;

		if (carData.ByRealMoney)
		{
			_priceCaption.text = carData.Price + _realValute;
		}
		else
		{
			_priceCaption.text = carData.Price + _valute;
		}
	}

	private void OnUnlockClick()
	{
		if (_carData.ByRealMoney)
		{
			UnlockByPremiumValute();
			return;
		}
		UnlockByDefualtValute();
	}
	
	private void UnlockByDefualtValute()
	{
		if (PlayerData.Coins.Value < _carChager.CurrentCarData.Price)
		{
			return;
		}
		PlayerData.Coins.Value -= _carChager.CurrentCarData.Price;
		PlayerData.AddUnlockedCar(_carChager.CurrentCarData, new() { 0 });
	}

	private void UnlockByPremiumValute()
	{
		Debug.Log("Тут должны быть внутриигровые покупки");
		PlayerData.AddUnlockedCar(_carChager.CurrentCarData, new() { 0 });
	}
}
