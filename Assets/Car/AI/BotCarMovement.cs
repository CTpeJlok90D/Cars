using UnityEngine;

public class BotCarMovement : MonoBehaviour
{
	[SerializeField] private SimpleCar _car;
	[SerializeField] private Rigidbody _carRigidbody;
	[SerializeField] private float _rotateAccusity = 1;
	[SerializeField] private float _minAcceptebleDistanceToTarget = 2;
	[SerializeField] private float _minSpeedToStop;
	[SerializeField] private AnimationCurve _carSpeedPerDistance;
	[SerializeField] private AnimationCurve _rotateAnglePerCross;
	[SerializeField] private float _distanceToBoost = 15;

	public void Move(Vector3 position)
	{
		Vector3 delta = (_car.transform.position - position).normalized;

		Vector3 frontCross = Vector3.Cross(delta, _car.transform.forward);
		Vector3 rightCross = Vector3.Cross(delta, _car.transform.right);
		float gasDirection = rightCross.y < 0 ? 1 : -1;

		if (frontCross.y < -_rotateAccusity)
		{
			_car.CurrentSteeringInput = -1 * gasDirection;
		}
		else if (frontCross.y > _rotateAccusity)
		{
			_car.CurrentSteeringInput = 1 * gasDirection;
		}
		else
		{
			_car.CurrentSteeringInput = 0;
		}

		float distance = Vector3.Distance(_car.transform.position, position);

		if (distance > _distanceToBoost && Mathf.Abs(frontCross.y) < _rotateAccusity)
		{
			_car.Boost();
		}
		else
		{
			_car.StopBoost();
		}

		if (distance > _minAcceptebleDistanceToTarget)
		{
			_car.CurrentMotoringInput = _carSpeedPerDistance.Evaluate(distance) * gasDirection;
		}
		else
		{
			_car.Handbrake();
		}
	}
}
