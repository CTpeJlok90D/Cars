using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CarData")]
public class CarData : ScriptableObject
{
	[SerializeField] private string _viewName;
	[SerializeField] private SimpleCar _viewPrefab;
	[SerializeField] private List<ColorInfo> _colorPrices = new() { };
	[Range(0, 200)]
	[SerializeField] private float _speed;
	[Range(0, 200)]
	[SerializeField] private float _break;
	[Range(0, 200)]
	[SerializeField] private float _nitro;
	[SerializeField] private bool _isUnlocked;
	[Header("Price")]
	[SerializeField] private bool _byRealMoney;
	[SerializeField] private int _price;

	public string ViewName => _viewName;
	public SimpleCar ViewPrefab => _viewPrefab;
	public List<ColorInfo> ColorPrices => _colorPrices;
	public float Speed => _speed;
	public float Break => _break;
	public float Nitro => _nitro;
	public bool ByRealMoney => _byRealMoney;
	public bool IsUnlocked
	{
		get
		{
			return PlayerData.CarInfoByName(name) != null;
		}
	}
	public PlayerData PlayerData => PlayerDataContainer.Instance.Data;
	public int Price => _price;

	[Serializable]
	public struct ColorInfo
	{
		public Color Color;
		public int Price;
		public bool ByAdvertisement;
	}
}
