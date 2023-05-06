using TMPro;
using UnityEngine;

public class LookingForApponentsAnimation : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private TMP_Text _mainText; 
	[SerializeField] private string[] _captions;
	[SerializeField] private float _timeToChange = 1.5f;

	private float _timer;

	private int _currentCaptionIndex;

	public int CurrentCaptionIndex
	{
		get
		{
			return _currentCaptionIndex; 
		}
		set
		{
			_currentCaptionIndex = value;
			if (_currentCaptionIndex >= _captions.Length)
			{
				_currentCaptionIndex = 0;
			}
			if (_currentCaptionIndex < 0)
			{
				_currentCaptionIndex = _captions.Length - 1;
			}
		}
	}

	private void Start()
	{
		_text.fontSize = _mainText.fontSize;
	}

	private void Update()
	{
		_timer += Time.deltaTime;
		if (_timer > _timeToChange)
		{
			_timer = 0;
			CurrentCaptionIndex++;
			_text.text = _captions[CurrentCaptionIndex];
		}
	}
}
