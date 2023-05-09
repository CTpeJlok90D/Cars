using System.Collections;
using TMPro;
using UnityEngine;

public class СountdownTimer : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private string _zeroCaption = "GO!";
	[SerializeField] private Color _showColor;
	[SerializeField] private Color _hideColor;

	public void StartCooldown(float timer)
	{
		StartCoroutine(CooldownCorutine(timer));
	}

	private IEnumerator CooldownCorutine(float timer)
	{
		while (timer > 0)
		{
			if ((int)timer == 0)
			{
				_text.text = _zeroCaption;
			}
			else
			{
				_text.text = ((int)timer).ToString();
			}
			_text.color = Color.Lerp(_hideColor, _showColor, timer - (int)timer);
			timer -= Time.deltaTime;
			yield return null;
		}
		_text.text = "";
	}
}
