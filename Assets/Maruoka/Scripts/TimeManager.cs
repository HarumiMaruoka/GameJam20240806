using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private float _time;

    private TimeSpan _timer;

    private void Start()
    {
        _timer = TimeSpan.FromSeconds(_time);
    }

    private void Update()
    {
        _timer = _timer.Subtract(TimeSpan.FromSeconds(Time.deltaTime));
        _text.text = _timer.ToString(@"mm\:ss");

        if (_timer.TotalSeconds <= 0)
        {
            _timer = TimeSpan.FromSeconds(_time);
        }
    }
}
