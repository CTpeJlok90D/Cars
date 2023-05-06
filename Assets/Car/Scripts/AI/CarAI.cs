
using UnityEngine;

public class CarAI : CarController
{
    [SerializeField] private BlockBallTask _blockBall;
    [SerializeField] private HitBallTask _hitBall;
	[SerializeField] private Ball _ball;
	[SerializeField] private Gates _ownGates;
	[SerializeField] private Gates _enemyGates;
	[SerializeField] private BotCarMovement _movement;

	private void Update()
    {
		if (_ball != null)
		{
			_movement.Move(_ball.transform.position);
		}
		//if (Vector3.Distance(_ownGates.transform.position, _ball.transform.position) > Vector3.Distance(_ownGates.transform.position, _enemyGates.transform.position) / 3)
		//{
		//	_hitBall.Execute();
		//}
		//else
		//{
		//	_blockBall.Execute();
		//}
	}
}
