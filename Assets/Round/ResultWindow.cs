using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultWindow : MonoBehaviour
{
	[SerializeField] private Button _restoreRaitingButton;
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

	private void OnEnable()
	{
		_restoreRaitingButton.onClick.AddListener(OnRestoreButtonClick);
	}

	private void OnDisable()
	{
		_restoreRaitingButton.onClick.RemoveListener(OnRestoreButtonClick);
	}

	public void ShowResults(Round.Result result, int coinsReward, int raitingReward)
	{
		_result = result;
		_raitingReward = raitingReward;

		_winObject.SetActive(result == Round.Result.Win);
		_loseObject.SetActive(result == Round.Result.Lose);
		_drawObject.SetActive(result == Round.Result.Draw);
		_restoreRaitingButton.gameObject.SetActive(_result == Round.Result.Lose);


		StartCoroutine(_coinsRewardCaption.ValueTextAnimation(0, coinsReward, _coinAnimationSpeed));
		StartCoroutine(_raitingRewardCaption.ValueTextAnimation(0, raitingReward, _raitingAnimationSpeed));
	}

	private void OnRestoreButtonClick()
	{
		Debug.Log("Тут могла быть ваша реклама");

		StartCoroutine(_raitingRewardCaption.ValueTextAnimation(RaitingReward, 0, 10));
		PlayerDataContainer.Instance.Data.Raiting.Value -= RaitingReward;
		_restoreRaitingButton.gameObject.SetActive(false);
	}
}
