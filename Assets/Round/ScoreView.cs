using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private TeamScore _teamScore;

	private void OnEnable()
	{
		_teamScore.Changed.AddListener(OnScoreChange);
	}

	private void OnDisable()
	{
		_teamScore.Changed.RemoveListener(OnScoreChange);
	}

	private void OnScoreChange(int value)
	{
		UpdateText();
	}

	public void UpdateText()
	{
		_text.text = $"{_teamScore.Current}";
	}
}
