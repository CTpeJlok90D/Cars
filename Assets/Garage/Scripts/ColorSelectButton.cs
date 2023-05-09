using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButton : MonoBehaviour
{
	[SerializeField] private Button _selectButton;
	[SerializeField] private Button _unlockButton;
	[SerializeField] private Button _advertisementButton;
	[SerializeField] private Image _image;
	[SerializeField] private GameObject _lock;
	[SerializeField] private TMP_Text _priceCaption;

	private CarCustomizer _cutomizer;


	private int _carColorID;
	private CarData _carData;
	private CarData.ColorInfo _colorInfo;

	public PlayerData PlayerData => PlayerDataContainer.Instance.Data;

	public ColorSelectButton Init(CarData carData, CarData.ColorInfo colorInfo, CarCustomizer customizer, int carColorId)
	{
		_carData = carData;
		_colorInfo = colorInfo;

		_image.color = colorInfo.Color;
		_cutomizer = customizer;
		_carColorID = carColorId;

		PlayerData.UnlockedStateCarInfo info = PlayerData.CarInfoByName(carData.name);

		bool colorIsUnlocked = info != null && info.UnlockedColors.Contains(_carColorID);
		bool carIsunlocked = info != null;

		_advertisementButton.gameObject.SetActive(colorIsUnlocked == false && colorInfo.ByAdvertisement);
		_advertisementButton.interactable = carIsunlocked;
		_unlockButton.gameObject.SetActive(colorInfo.ByAdvertisement == false);

		_unlockButton.interactable = carIsunlocked;
		_lock.gameObject.SetActive(colorIsUnlocked == false && colorInfo.ByAdvertisement == false);
		_priceCaption.gameObject.SetActive(colorIsUnlocked == false && colorInfo.ByAdvertisement == false);
		_selectButton.interactable = colorIsUnlocked;
		_priceCaption.text = colorInfo.Price.ToString() + "$";

		return this;
	}

	private void OnEnable()
	{
		_selectButton.onClick.AddListener(CustomizerApplyColor);
		_advertisementButton.onClick.AddListener(UnlockFree);
		_unlockButton.onClick.AddListener(UnlockColor);
	}

	private void OnDisable()
	{
		_selectButton.onClick.RemoveListener(CustomizerApplyColor);
		_advertisementButton.onClick.RemoveListener(UnlockFree);
		_unlockButton.onClick.RemoveListener(UnlockColor);
	}

	private void UnlockColor()
	{
		if (PlayerData.Coins.Value < _colorInfo.Price)
		{
			return;
		}

		UnlockFree();
		PlayerData.UnlockedStateCarInfo info = PlayerData.CarInfoByName(_carData.name);
		PlayerData.AddUnlockedCar(_carData, new() { _carColorID });
		PlayerData.Coins.Value -= _colorInfo.Price;
	}

	private void UnlockFree()
	{
		Debug.Log("Тут могла бы бить ваша реклама");
		PlayerData.UnlockedStateCarInfo info = PlayerData.CarInfoByName(_carData.name);
		PlayerData.AddUnlockedCar(_carData, new() { _carColorID });
	}

	private void CustomizerApplyColor()
	{
		_cutomizer.Color = _image.color;
		PlayerDataContainer.Instance.CarColor = _cutomizer.Color;
	}
}