using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private TeamScore _playerScore;
	[SerializeField] private TeamScore _botScore;
	[SerializeField] private string _space = "  ";

	private void OnEnable()
	{
		_playerScore.Changed.AddListener(OnScoreChange);
		_botScore.Changed.AddListener(OnScoreChange);
	}

	private void OnDisable()
	{
		_playerScore.Changed.RemoveListener(OnScoreChange);
		_botScore.Changed.RemoveListener(OnScoreChange);
	}

	private void OnScoreChange(int value)
	{
		UpdateText();
	}

	public void UpdateText()
	{
		_text.text = $"{_playerScore.Current} {_space} {_botScore.Current}";
	}

	private void OnValidate()
	{
		_text.text = $"{_playerScore.Current} {_space} {_botScore.Current}";
	}
}
