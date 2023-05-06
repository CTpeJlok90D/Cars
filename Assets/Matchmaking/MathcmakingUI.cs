using TMPro;
using UnityEngine;

public class MathcmakingUI : MonoBehaviour
{
	[SerializeField] private GameObject _lookingForApponentsCaption;
	[SerializeField] private GameObject _opponentFoundCaption;
	[SerializeField] private MathcmakingBotCarLoader _botCarLoader;

	private void OnEnable()
	{
		_botCarLoader.OpponentFound.AddListener(OnOpponentFound);
	}
	private void OnDisable()
	{
		_botCarLoader.OpponentFound.RemoveListener(OnOpponentFound);
	}

	private void OnOpponentFound()
	{
		_lookingForApponentsCaption.gameObject.SetActive(false);
		_opponentFoundCaption.gameObject.SetActive(true);
	}
}
