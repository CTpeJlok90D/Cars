public static class InputSingletone
{

	private static InputMap _instance;
	public static InputMap Instance 
	{
		get
		{
			if (_instance == null)
			{
				_instance = new InputMap();
				_instance.Enable();
			}

			return _instance;
		}
	} 
}
