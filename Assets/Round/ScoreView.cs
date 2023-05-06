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
		_playerScore.Changed += OnScoreChange;
		_botScore.Changed += OnScoreChange;
	}

	private void OnDisable()
	{
		_playerScore.Changed -= OnScoreChange;
		_botScore.Changed -= OnScoreChange;
	}

	private void OnScoreChange(object sender, int value)
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
