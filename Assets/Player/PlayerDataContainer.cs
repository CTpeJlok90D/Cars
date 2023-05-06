using UnityEngine;

public class PlayerDataContainer : CarDataContainer
{
	private static PlayerDataContainer _instance;
	[SerializeField] private PlayerData _data = new();

	public PlayerData Data => _data;

	public static bool HaveInstance => _instance != null;
	public static PlayerDataContainer Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject instance = new();
				DontDestroyOnLoad(instance);
				PlayerDataContainer container = instance.AddComponent<PlayerDataContainer>();
				instance.name = container.GetType().Name;
				_instance = container;
			}
			return _instance;
		}
	}
}
