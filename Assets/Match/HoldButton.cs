using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldButton : Button, IPointerDownHandler, IPointerUpHandler
{
	private UnityEvent _down = new();
	private UnityEvent _up = new();

	public UnityEvent Down => _down;
	public UnityEvent Up => _up;

	public new void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		_down.Invoke();
	}

	public new void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		_up.Invoke();
	}
}
