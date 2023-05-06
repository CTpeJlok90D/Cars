using UnityEngine;

public class MatchCarLoader : MonoBehaviour
{
	[SerializeField] private Mode mode;
	[SerializeField] private CarController _carController;
	[SerializeField] private Vector3 _spawnPosition;
	[SerializeField] private Quaternion _spawnDirection;
	private void Awake()
	{
		CarDataContainer container;
		if (mode is Mode.Player)
		{
			container = PlayerDataContainer.Instance;
		}
		else
		{
			container = BotCarDataContainer.Instance;
		}
		_carController.Car = Instantiate(container.CurrentCar.ViewPrefab, _spawnPosition, _spawnDirection);
		if (_carController.Car.TryGetComponent(out CarCustomizer customizer))
		{
			customizer.Color = container.CarColor;
		}
	}

	private enum Mode
	{
		Bot,
		Player
	}
}