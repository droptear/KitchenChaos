using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager Instance { get; private set; }

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    private State _state;
    private float _waitingToStartTimer = 1.0f;
    private float _countdownToStartTimer = 3.0f;
    private float _gamePlayingTimer = 10.0f;

    private void Awake()
    {
        Instance = this;
        _state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.WaitingToStart:
                _waitingToStartTimer -= Time.deltaTime;
                if (_waitingToStartTimer < 0)
                {
                    _state = State.CountdownToStart;
                }
                break;

            case State.CountdownToStart:
                _countdownToStartTimer -= Time.deltaTime;
                if (_countdownToStartTimer < 0)
                {
                    _state = State.GamePlaying;
                }
                break;

            case State.GamePlaying:
                _gamePlayingTimer -= Time.deltaTime;
                if (_gamePlayingTimer < 0)
                {
                    _state = State.GameOver;
                }
                break;

            case State.GameOver:
                break;
        }

        Debug.Log(_state);
    }

    public bool IsGamePlaying()
    {
        return (_state == State.GamePlaying);
    }
}
