using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballbase : MonoBehaviour
{
    private Vector3 _startPositon;
    private Vector3 _startSpeed;
    [Header("randomization")]
    public Vector2 randspeedY = new Vector2(1, 3);
    public Vector2 randspeedX = new Vector2(1, 3);

    public Vector3 ballspeed = new Vector3(1,1);
    private bool _canMove = false;
    

    public string keyTocheck = "player";
   void Update()
    {
        if (!_canMove) return;
        transform.Translate(ballspeed);
    }

    private void Awake()
    {
        _startPositon = transform.position;
        _startSpeed = ballspeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {  // se bater no jogador inverte a posição 
        if (collision.gameObject.tag == keyTocheck)//se a tag do objeto for igual a player 
        {
            _OnPlayerCollision();
            
        }
        else { // se bater em em outro objeto inverte a de y
            ballspeed.y *= -1;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetBall();
    }


    private void _OnPlayerCollision()
    {
        ballspeed.x *= -1;
        //RANDOMIZA AS POSIÇÕES DA BOLA
        float rand = Random.Range(randspeedY.x, randspeedY.y);
        if (ballspeed.x < 0)
        {
            rand = -rand;
        }
        
        ballspeed.x = rand;
    }
    public void ResetBall()
    {
        transform.position = _startPositon;
        ballspeed = _startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }

}



