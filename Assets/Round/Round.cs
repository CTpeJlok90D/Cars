using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Round : MonoBehaviour
{
	[SerializeField] private List<TeamScore> _teams = new();
	[SerializeField] private List<CarPositionInfo> _cars;
	[SerializeField] private List<ObjectPositionInfo> _infos = new();
	[SerializeField] private float _timeBetweenRounds = 2.5f;
	[SerializeField] private float _gameTime = 180f;
	[SerializeField] private ResultWindow _resultWindow;
	[SerializeField] private GameObject _inGameCanvas;
	[SerializeField] private Ball _ball;
	[Header("Coints reward")]
	[SerializeField] private int _winCoinReward = 30;
	[SerializeField] private int _loseCoinReward = 15;
	[SerializeField] private int _drawCoinReward = 20;
	[Header("Raiting reward")]
	[SerializeField] private int _winRaitingReward = 100;
	[SerializeField] private int _loseRaitingReward = -10;
	[SerializeField] private int _drawRaitingReward = 50;

	private bool _timeIsTicking = true;
	private PlayerData PlayerData => PlayerDataContainer.Instance.Data;

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
	}

	public void Draw()
	{
		PlayerData.Coins.Value += _drawCoinReward;
		PlayerData.Raiting.Value += _drawRaitingReward;
		_resultWindow.ShowResults(Result.Draw, _drawCoinReward, _drawRaitingReward);
	}

	public void Win() 
	{
		PlayerData.Coins.Value += _winCoinReward;
		PlayerData.Raiting.Value += _winRaitingReward;
		_resultWindow.ShowResults(Result.Win, _winCoinReward, _winRaitingReward);
	}

	public void Lose()
	{
		PlayerData.Coins.Value += _loseCoinReward;
		PlayerData.Raiting.Value += _loseRaitingReward;
		_resultWindow.ShowResults(Result.Lose, _loseCoinReward, _loseRaitingReward);
	}

	private void OnGoal(int value)
	{
		RestartRound();
	}

	public void RestartRound()
	{
		foreach (ObjectPositionInfo info in _infos)
		{
			info.Object.position = info.Position;
			info.Object.rotation = info.Rotation;
			if (info.Rigidbody != null)
			{
				info.Rigidbody.velocity = Vector3.zero;
				info.Rigidbody.angularVelocity = Vector3.zero;
			}
		}
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
