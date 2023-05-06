using UnityEngine;

public class BotCarMovement : MonoBehaviour
{
	[SerializeField] private CarController _carController;
	[SerializeField] private float _rotateAccusity = 1;
	[SerializeField] private float _minAcceptebleDistanceToTarget = 2;
	[SerializeField] private float _minSpeedToStop;
	[SerializeField] private AnimationCurve _carSpeedPerDistance;
	[SerializeField] private float _distanceToBoost = 15;

	public SimpleCar Car => _carController.Car;

	public void Move(Vector3 position)
	{
		Vector3 delta = (Car.transform.position - position).normalized;

		Vector3 frontCross = Vector3.Cross(delta, Car.transform.forward);
		Vector3 rightCross = Vector3.Cross(delta, Car.transform.right);
		float gasDirection = rightCross.y < 0 ? 1 : -1;

		if (frontCross.y < -_rotateAccusity)
		{
			Car.CurrentSteeringInput = -1 * gasDirection;
		}
		else if (frontCross.y > _rotateAccusity)
		{
			Car.CurrentSteeringInput = 1 * gasDirection;
		}
		else
		{
			Car.CurrentSteeringInput = 0;
		}

		float distance = Vector3.Distance(Car.transform.position, position);

		if (distance > _distanceToBoost && Mathf.Abs(frontCross.y) < _rotateAccusity)
		{
			Car.Boost();
		}
		else
		{
			Car.StopBoost();
		}

		if (distance > _minAcceptebleDistanceToTarget)
		{
			Car.CurrentMotoringInput = _carSpeedPerDistance.Evaluate(distance) * gasDirection;
		}
		else
		{
			Car.Break();
		}
	}
}
