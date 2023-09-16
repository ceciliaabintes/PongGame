using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gamemaneger : MonoBehaviour
{
    public ballbase Ballbase;
    public float timeToSetBallFree = 1.5f;
    public static gamemaneger Instance;
    public stateMachine StateMachine;
    [Header("Menus")]
    public GameObject uiMenu;
    private void Awake()
    {
        Instance = this;
    }

   
    public void ResetBall()
    {
        Ballbase.CanMove(false);
        Ballbase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }
    private void SetBallFree()
    {
        Ballbase.CanMove(true);
    }

    public void StartGame()
    {
        Ballbase.CanMove(true);
    }
    public void EndGame()
    {
        StateMachine.SwitchState(stateMachine.States.END_GAME);
    }

    public void showMenu()
    {
        uiMenu.SetActive(true);
        Ballbase.CanMove(false);
    }

}
