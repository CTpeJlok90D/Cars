using TMPro.EditorUtilities;
using UnityEngine;

public class BlockBallTask : AITask
{
	[SerializeField] private BotCarMovement _movement;
	[SerializeField] private SimpleCar _enemy;
	[SerializeField] private Ball _ball;
	[SerializeField] private Gates _ownGates;
	[SerializeField] private Gates _enemyGates;
	[SerializeField] private float _defendGatesDistance = 3;

	private Transform _targetPosition;

	private void Awake()
	{
		_targetPosition = new GameObject().transform;
		_targetPosition.name = $"{name}'s block target position";
	}

	private void Update()
	{
		_targetPosition.position = Vector3.Lerp(_ownGates.transform.position, _ball.transform.position, Vector3.Distance(_ownGates.transform.position, _ball.transform.position) / Vector3.Distance(_ownGates.transform.position, _enemyGates.transform.position));
	}

	public override void Execute()
	{
		if (Vector3.Distance(_movement.transform.position, _ball.transform.position) > _defendGatesDistance && Vector3.Distance(_enemy.transform.position, _ball.transform.position) < Vector3.Distance(_movement.transform.position, _ball.transform.position))
		{
			_movement.Move(_targetPosition.position);
			return;
		}
		_movement.Move(_ball.transform.position);
	}
}