using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
	[SerializeField] private List<TeamScore> _teams = new();
	[SerializeField] private List<CarPositionInfo> _cars;
	[SerializeField] private List<ObjectPositionInfo> _infos = new();
	[SerializeField] private float _timeAfterRound = 2.5f;
	[SerializeField] private float _preRoundTime = 3.9f;
	[SerializeField] private float _gameTime = 180f;
	[SerializeField] private ResultWindow _resultWindow;
	[SerializeField] private GameObject _inGameCanvas;
	[SerializeField] private Ball _ball;
	[SerializeField] private ÑountdownTimer _timer;
	[SerializeField] private GameObject _goalText;
	[SerializeField] private AudioSource _goualSource;
	[Header("Coints reward")]
	[SerializeField] private int _winCoinReward = 500;
	[SerializeField] private int _coinRewardPerGoal = 50;
	[SerializeField] private int _loseCoinReward = 100;
	[SerializeField] private int _drawCoinReward = 250;
	[Header("Raiting reward")]
	[SerializeField] private int _winMaxRaitingReward = 30;
	[SerializeField] private int _winMinRaitingReward = 35;
	[SerializeField] private int _loseMaxRaitingReward = -10;
	[SerializeField] private int _loseMinRaitingReward = -15;
	[SerializeField] private int _drawRaitingReward = 10;

	private bool _timeIsTicking = true;
	private PlayerData PlayerData => PlayerDataContainer.Instance.Data;
	public float GameTime => _gameTime;

	protected void OnEnable()
	{
		foreach (TeamScore teamScore in _teams)
		{
			teamScore.Changed.AddListener(OnGoal);
		}
	}

	protected void OnDisable()
	{
		foreach (TeamScore teamScore in _teams)
		{
			teamScore.Changed.AddListener(OnGoal);
		}
	}

	protected void Start()
	{
		foreach (CarPositionInfo car in _cars)
		{
			_infos.Add(new ObjectPositionInfo()
			{
				Object = car.Controller.Car.transform,
				Rigidbody = car.Controller.Car.Rigidbody,
				Position = car.Position,
				Rotation = car.Rotation
			});
		}

		Cursor.visible = false;

		DisableAllCars();
		StartCoroutine(PreRound());
	}

	private void Update()
	{
		TickTime();
	}

	private void TickTime()
	{
		if (_timeIsTicking == false)
		{
			return;
		}
		_gameTime -= Time.deltaTime;
		if (_gameTime < 0)
		{
			EndGame();
		}
	}

	public void EndGame()
	{
		DisableAllCars();
		Destroy(_ball);

		_timeIsTicking = false;
		_inGameCanvas.SetActive(false);
		_resultWindow.gameObject.SetActive(true);
		if (_teams[0].Current == _teams[1].Current)
		{
			Draw();
		}
		else if (_teams[0].Current > _teams[1].Current)
		{
			Win();
		}
		else
		{
			Lose();
		}

		Cursor.visible = true;
	}

	public void Draw()
	{
        PlayerData.Coins.Value += _drawCoinReward;
		PlayerData.Raiting.Value += _drawRaitingReward;

		_resultWindow.ShowResults(Result.Draw, _drawCoinReward, _drawRaitingReward);
	}

	public void Win() 
	{
		int coinReward = _winCoinReward + _coinRewardPerGoal * _teams[0].Current;
		int raitingReward = UnityEngine.Random.Range(_winMinRaitingReward, _winMaxRaitingReward + 1);

		PlayerData.WinCount++;
		PlayerData.Coins.Value += coinReward;
		PlayerData.Raiting.Value += raitingReward;
		_resultWindow.ShowResults(Result.Win, coinReward, raitingReward);
	}

	public void Lose()
	{
		int coinReward = _loseCoinReward;
		int raitingReward = UnityEngine.Random.Range(_loseMinRaitingReward, _loseMaxRaitingReward + 1);

		PlayerData.Coins.Value += coinReward;
		PlayerData.Raiting.Value += raitingReward;
		_resultWindow.ShowResults(Result.Lose, coinReward, raitingReward);
	}

	private void OnGoal(int value)
	{
		StartCoroutine(AfterGoalCoroutine());
	}

	private IEnumerator AfterGoalCoroutine()
	{
		_goualSource.Play();
		_goalText.SetActive(true);
		_ball.enabled = false;
		_timeIsTicking = false;

		DisableAllCars();

		float timer = _timeAfterRound;
		while (timer > 0)
		{
			yield return null;
			timer -= Time.deltaTime;
		}

		_ball.enabled = true;
		_timeIsTicking = true;
		_goalText.SetActive(false);
		RestartRound();
	}

	private void DisableAllCars()
	{
		foreach (CarPositionInfo car in _cars)
		{
			car.Controller.Car.Disabled = true;
		}
	}

	private IEnumerator PreRound()
	{
		_timer.StartCooldown(_preRoundTime);
		_timeIsTicking = false;
		float time = _preRoundTime;

		while (time > 0)
		{
			time -= Time.deltaTime;
			yield return null;
		}

		foreach (CarPositionInfo car in _cars)
		{
			car.Controller.Car.Disabled = false;
		}

		_timeIsTicking = true;
	}

	public void RestartRound()
	{
		foreach (ObjectPositionInfo info in _infos)
		{
			info.Object.position = info.Position;
			info.Object.rotation = info.Rotation;
			if (info.Rigidbody != null)
			{
				info.Rigidbody.position = info.Position;
				info.Rigidbody.rotation = info.Rotation.normalized;
				info.Rigidbody.velocity = Vector3.zero;
				info.Rigidbody.angularVelocity = Vector3.zero;
			}
		}
		StartCoroutine(PreRound());
	}

	[Serializable]
	public enum Result
	{
		Win,
		Lose,
		Draw
	}

	[Serializable]
	private class ObjectPositionInfo
	{
		public Transform Object;
		public Rigidbody Rigidbody;
		public Vector3 Position;
		public Quaternion Rotation;
	}

	[Serializable]
	private class CarPositionInfo
	{
		public CarController Controller;
		public Vector3 Position;
		public Quaternion Rotation;
	}
}
