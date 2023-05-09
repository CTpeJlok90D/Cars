using TMPro;
using UnityEngine;

public class BotRaitingRandomazer : MonoBehaviour
{
	[SerializeField] private int _maxRaitingDispason;
	[SerializeField] private int _minRaitingDispason;
	[SerializeField] private TMP_Text _text;

	private void OnEnable()
	{
		_text.text = (Random.Range(_minRaitingDispason, _maxRaitingDispason + 1) + PlayerDataContainer.Instance.Data.Raiting.Value).ToString();
	}
}
