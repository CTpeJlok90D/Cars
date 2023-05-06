using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButton : MonoBehaviour
{
	[SerializeField] private Button _selectButton;
	[SerializeField] private Button _unlockButton;
	[SerializeField] private Image _image;
	[SerializeField] private GameObject _lock;
	[SerializeField] private TMP_Text _priceCaption;

	private CarCustomizer _cutomizer;

	private string _carName;
	private int _carColorID;
	private int _price;

	public PlayerData PlayerData => PlayerDataContainer.Instance.Data;

	public ColorSelectButton Init(Color color, CarCustomizer customizer, int price, string carName, int carColorId)
	{
		_image.color = color;
		_cutomizer = customizer;

		_price = price;
		_carName = carName;
		_carColorID = carColorId;

		PlayerData.UnlockedStateCarInfo info = PlayerData.CarInfoByName(_carName);

		bool colorIsUnlocked = info != null && info.UnlockedColors.Contains(_carColorID);

		_unlockButton.interactable = info != null;
		_lock.gameObject.SetActive(colorIsUnlocked == false);
		_priceCaption.gameObject.SetActive(colorIsUnlocked == false);
		_selectButton.interactable = colorIsUnlocked;
		_priceCaption.text = price.ToString() + "$";

		return this;
	}

	private void OnEnable()
	{
		_selectButton.onClick.AddListener(CustomizerApplyColor);
		_unlockButton.onClick.AddListener(UnlockColor);
	}

	private void OnDisable()
	{
		_selectButton.onClick.RemoveListener(CustomizerApplyColor);
		_unlockButton.onClick.RemoveListener(UnlockColor);
	}

	private void UnlockColor()
	{
		if (PlayerData.Coins.Value < _price)
		{
			return;
		}

		PlayerData.UnlockedStateCarInfo info = PlayerData.CarInfoByName(_carName);
		info.UnlockedColors.Add(_carColorID);
		PlayerData.Coins.Value -= _price;

		// Знаю, глупо. Но мне нужно было вызвать event о том, что значение изменилось. А для этого нужно изменить value
		// TODO: по возможности убрать костыль
		PlayerData.UnlockedCars.Value = PlayerData.UnlockedCars.Value;
	}

	private void CustomizerApplyColor()
	{
		_cutomizer.Color = _image.color;
		PlayerDataContainer.Instance.CarColor = _cutomizer.Color;
	}
}