using System;
using System.Collections;
using TMPro;
using UnityEngine;

public static class TMP_textExtentions
{
	public static IEnumerator ValueTextAnimation(this TMP_Text text, float oldValue, float newValue, float speed = 1)
	{ 
		while((int)oldValue != (int)newValue)
		{
			int valueMoveDirection = Math.Sign(newValue - oldValue);
			text.text = ((int)oldValue).ToString();
			oldValue += valueMoveDirection * Time.deltaTime * speed;
			yield return null;
		}
		text.text = ((int)oldValue).ToString();
	}
}
