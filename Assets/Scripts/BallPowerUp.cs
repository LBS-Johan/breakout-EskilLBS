using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallPowerUp : MonoBehaviour
{
    [SerializeField] GameObject ball;

    [SerializeField] float downSpeed = -2f;
    Rigidbody2D rb;

    private void Update()
    {
        rb.velocity = new Vector2(0, downSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Instantiate(ball);
        }
    }
}
