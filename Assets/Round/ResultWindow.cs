using TMPro;
using UnityEngine;

public class ResultWindow : MonoBehaviour
{
	[SerializeField] private GameObject _winObject;
	[SerializeField] private GameObject _loseObject;
	[SerializeField] private GameObject _drawObject;
	[SerializeField] private TMP_Text _coinsRewardCaption;
	[SerializeField] private TMP_Text _raitingRewardCaption;
	[SerializeField] private float _coinAnimationSpeed = 10f;
	[SerializeField] private float _raitingAnimationSpeed = 25f;

	private Round.Result _result;
	private int _raitingReward;

	public Round.Result Result => _result;
	public int RaitingReward => _raitingReward;

	public void ShowResults(Round.Result result, int coinsReward, int raitingReward)
	{
		_result = result;
		_raitingReward = raitingReward;

		_winObject.SetActive(result == Round.Result.Win);
		_loseObject.SetActive(result == Round.Result.Lose);
		_drawObject.SetActive(result == Round.Result.Draw);


		StartCoroutine(_coinsRewardCaption.ValueTextAnimation(0, coinsReward, _coinAnimationSpeed));
		StartCoroutine(_raitingRewardCaption.ValueTextAnimation(0, raitingReward, _raitingAnimationSpeed));
	}
}
