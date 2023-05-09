using UnityEngine;

public class CarStabilization : MonoBehaviour
{
	[SerializeField] private Rigidbody _carRigidbody;
	[SerializeField] private float _stabilizationForce;

	protected void FixedUpdate()
	{
		Vector3 stabilisationTorque = Vector3.Cross(_carRigidbody.rotation * Vector3.up, Vector3.up) * _stabilizationForce * _carRigidbody.mass;

		_carRigidbody.AddTorque(stabilisationTorque);
	}
}
