using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarCustomizer : MonoBehaviour
{
	[SerializeField] private MeshRenderer _car;
	[SerializeField] private int _materialIndex = 0;
	[SerializeField] private UnityEvent<Color> _colorChanged = new();

	public UnityEvent<Color> ColorChanged => _colorChanged;

	public Color Color
	{
		get
		{
			return _car.materials[_materialIndex].color;
		}
		set
		{
			_car.materials[_materialIndex].color = value;
			_colorChanged.Invoke(value);
		}
	}
}
