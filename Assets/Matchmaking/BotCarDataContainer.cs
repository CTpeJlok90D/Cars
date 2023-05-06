using UnityEngine;

public class BotCarDataContainer : CarDataContainer
{
	private static BotCarDataContainer _instance;
	public static BotCarDataContainer Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject instance = new();
				DontDestroyOnLoad(instance);
				BotCarDataContainer container = instance.AddComponent<BotCarDataContainer>();
				instance.name = container.GetType().Name;
				_instance = container;
			}
			return _instance;
		}
	}
}
