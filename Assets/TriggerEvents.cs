using UnityEngine;
using UnityEngine.Events;

public sealed class TriggerEvents : MonoBehaviour
{
	[SerializeField] private UnityEvent<Collider> _onTriggerEnter;
	[SerializeField] private UnityEvent<Collider> _onTriggerStay;
	[SerializeField] private UnityEvent<Collider> _onTriggerExit;

	public UnityEvent<Collider> OnTriggerEnterEvent => _onTriggerEnter;
	public UnityEvent<Collider> OnTriggerStayEvent => _onTriggerStay;
	public UnityEvent<Collider> OnTriggerExitEvent => _onTriggerExit;


	private void OnTriggerEnter(Collider other)
	{
		_onTriggerEnter.Invoke(other);
	}

	private void OnTriggerStay(Collider other)
	{
		_onTriggerStay.Invoke(other);
	}

	private void OnTriggerExit(Collider other)
	{
		_onTriggerExit.Invoke(other);
	}
}
