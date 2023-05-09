using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeView : MonoBehaviour
{
	[SerializeField] private Round _round;
	[SerializeField] private TMP_Text _text;

	private void Update()
	{
		UpdateTimer();
	}

	private void UpdateTimer()
	{
		int seconds = (int)_round.GameTime % 60;
		int minuts = (int)_round.GameTime / 60;
		_text.text = $"{minuts}:{(seconds < 10 ? "0" + seconds : seconds)}";
	}
}
