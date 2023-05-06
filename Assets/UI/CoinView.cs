using System;
using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	private PlayerData PlayerData => PlayerDataContainer.Instance.Data;

	private void OnEnable()
	{
		PlayerData.Coins.Changed.AddListener(OnCoinCountChanged);
		_text.text = PlayerData.Coins.Value.ToString();
	}

	private void OnDisable()
	{
		if (PlayerDataContainer.HaveInstance)
		{
			PlayerData.Coins.Changed.RemoveListener(OnCoinCountChanged);
		}
	}

	private void OnCoinCountChanged(int newValue)
	{
		_text.text = newValue.ToString();
	}
}
