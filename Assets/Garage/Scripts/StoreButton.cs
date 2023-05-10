using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
	[SerializeField] private Button _storeButton;
	[SerializeField] private GameObject _store;
	[SerializeField] private GameObject _garage;

	private void OnEnable()
	{
		_storeButton.onClick.AddListener(ToogleStore);
	}

	private void OnDisable()
	{
		_storeButton.onClick.RemoveListener(ToogleStore);
	}

	private void ToogleStore()
	{
		_store.SetActive(_store.activeSelf == false);
		_garage.SetActive(_garage.activeSelf == false);
	}
}
