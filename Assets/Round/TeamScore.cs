using System;
using UnityEngine;
using UnityEngine.Events;

public class TeamScore : MonoBehaviour
{
	[SerializeField] private ReactiveVariable<int> _current = new(0);
	[SerializeField] private string _teamName;

	public int Current
	{
		get
		{
			return _current.Value;
		}
		set
		{
			_current.Value = value;
		}
	}
	public UnityEvent<int> Changed => _current.Changed;
	public string TeamName => _teamName;
}
