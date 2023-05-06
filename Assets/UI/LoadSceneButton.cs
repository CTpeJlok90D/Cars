using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
	[SerializeField] private Button _button;
	[SerializeField] private int _loadSceneIndex = 0;

	private void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	private void OnClick()
	{
		SceneManager.LoadScene(_loadSceneIndex);
	}
}
