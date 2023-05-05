using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ReactiveVariable<T> 
{
	[SerializeField] private UnityEvent<T> _changed = new();
	[SerializeField] private T _value;

	public UnityEvent<T> Changed => _changed;
	public T Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			_changed.Invoke(_value);
		}
	}

	public ReactiveVariable(T value)
	{
		_value = value;
	}
}