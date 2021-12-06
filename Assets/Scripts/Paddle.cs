using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;
    public float minX = 1.175f, maxX = 14.875f;

    private Ball ball;
    

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, -5f);
        float ballPosition = ball.transform.position.x;
        paddlePos.x = Mathf.Clamp(ballPosition, minX, maxX);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, -5f);
        float mousePosInBlock = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlock, minX, maxX);
        this.transform.position = paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            ball.GiveSpeedToTheBall();
    }
}
