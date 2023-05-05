using UnityEngine;
using UnityEngine.Events;

public class TeamScore : MonoBehaviour
{
	[SerializeField] private int _requestScoreToWin = 3;
	[SerializeField] private ReactiveVariable<int> _current = new(0);
	[SerializeField] private UnityEvent<TeamScore> _win;
	[SerializeField] private string _teamName;

	public int Current
	{
		get
		{
			return _current.Value;
		}
		set
		{
			if (value >= _requestScoreToWin)
			{
				_win.Invoke(this);
			}
			_current.Value = value;
		}
	}
	public UnityEvent<int> Changed => _current.Changed;
	public UnityEvent<TeamScore> Win => _win;
	public string TeamName => _teamName;
}
