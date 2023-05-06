using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarUnlockButton : MonoBehaviour
{
	[SerializeField] private Button _unlockButton;
	[SerializeField] private CarGarageChanger _carChager;
	[SerializeField] private TMP_Text _priceCaption;

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

		_priceCaption.text = carData.Price + "$";
	}

	private void OnUnlockClick()
	{
		if (PlayerData.Coins.Value < _carChager.CurrentCarData.Price)
		{
			return;
		}
		PlayerData.Coins.Value -= _carChager.CurrentCarData.Price;
		PlayerData.UnlockedCars.Value.Add(new()
		{
			Name = _carChager.CurrentCarData.name,
			UnlockedColors = new() { 0 }
		});

		PlayerData.UnlockedCars.Value = PlayerData.UnlockedCars.Value;
	}
}
