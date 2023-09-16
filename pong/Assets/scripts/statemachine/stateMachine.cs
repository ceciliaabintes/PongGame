using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMachine : MonoBehaviour
{
    public static stateMachine Instance;
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }
    public Dictionary<States, StateBase> ditionaryState;
    private StateBase _currentBase;
    public player Player;
    public float timeTostartGame = 1f;
    private void Awake()
    {
        Instance = this;
        ditionaryState = new Dictionary<States, StateBase>();
        ditionaryState.Add(States.MENU, new StateBase());
        ditionaryState.Add(States.PLAYING, new statePlaying());
        ditionaryState.Add(States.RESET_POSITION, new stateResetPosition());
        ditionaryState.Add(States.END_GAME, new stateEndGame());

        SwitchState(States.MENU);
    }

    public void SwitchState(States state)
    {
        if (_currentBase != null) _currentBase.OnStateExit();
        _currentBase = ditionaryState[state];
        if(_currentBase != null)_currentBase.OnStateEnter(Player);
    }

    private void Update()
    {
        if (_currentBase != null) _currentBase.OnStateStay();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchState(States.PLAYING);
        }
    }
    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}
