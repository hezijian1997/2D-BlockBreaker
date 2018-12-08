using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidth = 16f;
    [SerializeField] float min = 1f; 
    [SerializeField] float max = 15f;

    GameSession GameSession;
    Ball Ball;
	// Use this for initialization
	void Start ()
    {
        GameSession = FindObjectOfType<GameSession>();
        Ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), min, max);
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (GameSession.IsAutoPlayEnabled())
        {
            return Ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidth;
        }
    }
}
