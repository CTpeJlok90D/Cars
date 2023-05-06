using UnityEngine;

public class CameraRotating : MonoBehaviour
{
	[SerializeField] private float _rotateSpeed = 10;
	private void Update()
	{
		transform.Rotate(new Vector3(0, _rotateSpeed * Time.deltaTime, 0));
	}
}
