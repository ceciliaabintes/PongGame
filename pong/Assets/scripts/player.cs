using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class player : MonoBehaviour
{   public  Image UiplayerColor;
    public int maxpoints = 10;
    public float speed = 10f;
    [Header("KeySetup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;
   

    private void Awake()
    {
        ResetPlayer();
    }
        public void ResetPlayer()
        {
        currentPoints = 0;
         UpdatePoints();
        } 
      
    void Update()
    {
        if (Input.GetKey(keyCodeMoveUp)) {
            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * speed);
        }

        else if (Input.GetKey(keyCodeMoveDown)) {
            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * -speed);
        }
    }  
    public void ChangeColor(Color c)
    {
        UiplayerColor.color = c;
    }
        public void AddPoints()
    {
        currentPoints++;
        UpdatePoints();
        CheckMaxPoints();
    }
      private void UpdatePoints()
    {
        uiTextPoints.text = currentPoints.ToString();
    }
    private void CheckMaxPoints()
    {
        if (currentPoints >= maxpoints )
        {
            gamemaneger.Instance.EndGame();
        }
    }

}
