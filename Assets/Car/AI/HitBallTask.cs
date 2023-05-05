using System;
using UnityEngine;

public class HitBallTask : AITask
{
	[SerializeField] private BotCarMovement _movement;
	[SerializeField] private Gates _ownGates;
	[SerializeField] private Gates _enemyGates;
	[SerializeField] private Ball _ball;

	private Transform _targetPosition;

	public override void Execute()
	{
		_movement.Move(_targetPosition.transform.position);
	}

	private void Awake()
	{
		_targetPosition = new GameObject().transform;
		_targetPosition.name = $"{name}'s hits target position";
	}

	private void Update()
	{
		_targetPosition.position = Vector3.Lerp(_ownGates.transform.position, _ball.transform.position, Vector3.Distance(_ownGates.transform.position, _ball.transform.position) / Vector3.Distance(_ownGates.transform.position, _enemyGates.transform.position));
	}
}