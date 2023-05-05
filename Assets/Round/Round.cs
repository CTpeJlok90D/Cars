using System;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
	[SerializeField] private List<TeamScore> _teams = new();
	[SerializeField] private List<ObjectPositionInfo> _infos = new();

	private void OnEnable()
	{
		foreach (TeamScore teamScore in _teams)
		{
			teamScore.Win.AddListener(OnWin);
			teamScore.Changed.AddListener(OnGoal);
		}
	}

	private void OnDisable()
	{
		foreach (TeamScore teamScore in _teams)
		{
			teamScore.Win.RemoveListener(OnWin);
			teamScore.Changed.RemoveListener(OnGoal);
		}
	}

	private void OnWin(TeamScore teamScore)
	{
		Debug.Log($"{teamScore.TeamName} won!");
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
	private class ObjectPositionInfo
	{
		public Transform Object;
		public Rigidbody Rigidbody;
		public Vector3 Position;
		public Quaternion Rotation;
	}
}
