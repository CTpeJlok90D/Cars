using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ReactiveVariable<T> 
{
	[SerializeField] private T _value;

	private event EventHandler<T> _changed;

	public event EventHandler<T> Changed
	{
		add
		{
			_changed += value;
		}
		remove
		{
			_changed -= value;
		}
	}
	public T Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			_changed(this,_value);
		}
	}

	public ReactiveVariable(T value)
	{
		_value = value;
	}
}