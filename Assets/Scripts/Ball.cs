using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Rigidbody2D ballRG;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        ballRG = GetComponent<Rigidbody2D>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                ballRG.velocity = new Vector2(0f, 10f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballRG.velocity += new Vector2(Random.Range(-0.2f,0.2f), Random.Range(-0.2f,0.2f));
        if (hasStarted)
        {
            audio.Play();
        }
    }

    public void GiveSpeedToTheBall()
    {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ballRG.velocity = new Vector2(0f, 10f);
                ballRG.velocity += new Vector2(-3f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ballRG.velocity = new Vector2(0f, 10f);
                ballRG.velocity += new Vector2(3f, 0f);
            }
    }
}
