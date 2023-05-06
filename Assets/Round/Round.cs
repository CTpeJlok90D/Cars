using System;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
	[SerializeField] private List<TeamScore> _teams = new();
	[SerializeField] private List<CarPositionInfo> _cars;
	[SerializeField] private List<ObjectPositionInfo> _infos = new();

	protected void OnEnable()
	{
		foreach (TeamScore teamScore in _teams)
		{
			teamScore.Win.AddListener(OnWin);
			teamScore.Changed += OnGoal;
		}
	}

	protected void OnDisable()
	{
		foreach (TeamScore teamScore in _teams)
		{
			teamScore.Win.RemoveListener(OnWin);
			teamScore.Changed -= OnGoal;
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

	private void OnWin(TeamScore teamScore)
	{
		Debug.Log($"{teamScore.TeamName} lose!");
	}

	private void OnGoal(object sender, int value)
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
