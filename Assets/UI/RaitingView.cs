using TMPro;
using UnityEngine;

public class RaitingView : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	private PlayerData PlayerData => PlayerDataContainer.Instance.Data;

	private void OnEnable()
	{
		PlayerData.Raiting.Changed.AddListener(OnRaitingCountChanged);
		_text.text = PlayerData.Raiting.Value.ToString();
	}

	private void OnDisable()
	{
		if (PlayerDataContainer.HaveInstance)
		{
			PlayerData.Raiting.Changed.RemoveListener(OnRaitingCountChanged);
		}
	}

	private void OnRaitingCountChanged(int newValue)
	{
		_text.text = newValue.ToString();
	}
}
