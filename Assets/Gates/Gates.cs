using UnityEngine;

public class Gates : MonoBehaviour
{
	[SerializeField] private TriggerEvents _trigger;
	[SerializeField] private TeamScore _score;

	private void OnEnable()
	{
		_trigger.OnTriggerEnterEvent.AddListener(OnTriggerEnter);
	}

	private void OnTriggerEnter(Collider other) 
	{
		if (other.TryGetComponent(out Ball ball))
		{
			_score.Current++;
		}
	}
}
