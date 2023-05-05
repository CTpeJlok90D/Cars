using UnityEngine;

public class CarStabilization : MonoBehaviour
{
	[SerializeField] private Rigidbody _carRigidbody;
	[SerializeField] private float _stabilizationForce;

	private Vector3 _gravityForce;

	protected void FixedUpdate()
	{
		Vector3 stabilisationTorque = Vector3.Cross(_carRigidbody.rotation * Vector3.up, Vector3.up) * _stabilizationForce * _carRigidbody.mass;

		_carRigidbody.AddTorque(stabilisationTorque);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + _gravityForce);
	}
}
