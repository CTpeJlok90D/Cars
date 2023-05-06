using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	private PlayerData PlayerData => PlayerDataContainer.Instance.Data;

	private void OnEnable()
	{
		PlayerData.Coins.Changed += OnCoinCountChanged;
		OnCoinCountChanged(this, PlayerData.Coins.Value);
	}

	private void OnCoinCountChanged(object sender, int newValue)
	{
		_text.text = newValue.ToString();
	}
}
