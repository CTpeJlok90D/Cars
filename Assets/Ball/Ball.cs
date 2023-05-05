using UnityEngine;
public class Ball : MonoBehaviour
{
	[SerializeField] private float _punchForce;
	[SerializeField] private Rigidbody _rigidbody;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<SimpleCar>())
		{
			Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
			_rigidbody.AddForce((transform.position - collision.transform.position).normalized * _punchForce * rb.velocity.magnitude);
		}
	}
}
