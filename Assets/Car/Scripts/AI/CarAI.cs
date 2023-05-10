
using UnityEngine;

public class CarAI : CarController
{
	[SerializeField] private Ball _ball;
	[SerializeField] private BotCarMovement _movement;

	private void Update()
    {
		if (_ball != null)
		{
			_movement.Move(_ball.transform.position);
		}
	}
}
