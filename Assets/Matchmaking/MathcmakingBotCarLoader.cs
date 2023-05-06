using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MathcmakingBotCarLoader : MonoBehaviour
{
	[SerializeField] private CarShower _carShower;
	[SerializeField] private UnityEvent _opponentFounded;
	[SerializeField] private float _delayRangeMinValue = 5;
	[SerializeField] private float _delayRangeMaxValue = 1;
	[SerializeField] private float _startDelay = 1.5f;
	[SerializeField] private int _matchSceneNumber;

	public UnityEvent OpponentFound => _opponentFounded;

	private float _delay = 0;

	protected void Awake()
	{
		_delay = Random.Range(_delayRangeMinValue, _delayRangeMaxValue);
		StartCoroutine(StarMatchmaking(_delay));
	}

	private IEnumerator StarMatchmaking(float time)
	{
		while (time > 0)
		{
			time -= Time.deltaTime;
			yield return null;
		}

		LoadApponent();
	}

	private void LoadApponent()
	{
		CarData[] cars = Resources.LoadAll<CarData>("Cars");

		BotCarDataContainer.Instance.CurrentCar = cars[Random.Range(0, cars.Length)];
		_carShower.CurrentCarData = BotCarDataContainer.Instance.CurrentCar;
		BotCarDataContainer.Instance.CarColor = _carShower.CurrentCarData.ColorPrices[Random.Range(0, _carShower.CurrentCarData.ColorPrices.Count)].Color;
		_carShower.CarCusomizer.Color = BotCarDataContainer.Instance.CarColor;
		_opponentFounded.Invoke();

		StartCoroutine(StartMatch(_startDelay));
	}

	private IEnumerator StartMatch(float delay)
	{
		while (delay > 0)
		{
			delay -= Time.deltaTime;
			yield return null;
		}
		SceneManager.LoadScene(_matchSceneNumber);
	}
}
