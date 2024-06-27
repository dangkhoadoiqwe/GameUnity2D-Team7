using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public GameData currentGameData;
    public TextMeshProUGUI timerText;

    private float _timeLeft;
    private float _minutes;
    private float _seconds;
    private float _onSecondDown;
    private bool _timeOut;
    private bool _stopTimer;

    void Start()
    {
        _stopTimer = false;
        _timeOut = false;
        _timeLeft = currentGameData.selectboardData.timeInSeconds;
        _onSecondDown = _timeLeft - 1f;

        GameEvent.OnBoardComplete  += StopTimer;
        GameEvent.OnUnlockNextCategory += StopTimer;
    }

    private void OnDisable()
    {
        GameEvent.OnBoardComplete -= StopTimer;
        GameEvent.OnUnlockNextCategory -= StopTimer;
    }

    private void StopTimer()
    {
        _stopTimer = true;
    }

    void Update()
    {
        if (_stopTimer == false) _timeLeft -= Time.deltaTime;

        if (_timeLeft <= _onSecondDown)
        {
            _onSecondDown = _timeLeft - 1f;
        }
    }

    void OnGUI()
    {
        if (_timeOut == false)
        {
            if (_timeLeft > 0)
            {
                _minutes = Mathf.Floor(_timeLeft / 60);
                _seconds = Mathf.RoundToInt(_timeLeft % 60);

                timerText.text = _minutes.ToString("00") + ":" + _seconds.ToString("00");
            }
            else
            {
                _stopTimer = true;
                ActiveGameOverGUI();
            }
        }
    }

    private void ActiveGameOverGUI()
    {
        GameEvent.GameOverMethod();
        _timeOut = true;
    }
}
