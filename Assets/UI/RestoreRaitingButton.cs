using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestoreRaitingButton : MonoBehaviour
{
	[SerializeField] private Button _button;
	[SerializeField] private TMP_Text _raitingText;
	[SerializeField] private ResultWindow _results;

	private void Start()
	{
		_button.gameObject.SetActive(_results.Result != Round.Result.Lose);
	}

	private void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	private void OnClick()
	{
		Debug.Log("Тут могла быть ваша реклама");

		StartCoroutine(_raitingText.ValueTextAnimation(_results.RaitingReward, 0, 10));
		PlayerDataContainer.Instance.Data.Raiting.Value -= _results.RaitingReward;
	}
}
