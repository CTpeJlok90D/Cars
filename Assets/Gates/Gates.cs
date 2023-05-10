using UnityEngine;

public class Gates : MonoBehaviour
{
	[SerializeField] private TriggerEvents _trigger;
	[SerializeField] private TeamScore _score;
	[SerializeField] private ParticleSystem _particleSystem;

	private void OnEnable()
	{
		_trigger.OnTriggerEnterEvent.AddListener(OnTriggerEnter);
	}

	private void OnTriggerEnter(Collider other) 
	{
		if (other.TryGetComponent(out Ball ball) && ball.isActiveAndEnabled)
		{
			_score.Current++;
			_particleSystem.transform.position = ball.transform.position;
			_particleSystem.Play();
		}
	}
}
