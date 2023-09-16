using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class balltriger : MonoBehaviour
{
    public player Player;
    public string ballTag = "ball";
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.transform.tag == ballTag)
        {
            _CountPoints();
        }
    }
    private void _CountPoints()
    {
        stateMachine.Instance.ResetPosition();
        Player.AddPoints();
    }



}
