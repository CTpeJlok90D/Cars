using UnityEngine;

public class MatchmakingPlayerCarLoader : MonoBehaviour
{
	[SerializeField] private CarShower _carShower;

	private PlayerDataContainer PlayerData => PlayerDataContainer.Instance;

	private void Awake()
	{
		_carShower.CurrentCarData = PlayerData.CurrentCar;
		_carShower.CarCusomizer.Color = PlayerData.CarColor;
	}
}
