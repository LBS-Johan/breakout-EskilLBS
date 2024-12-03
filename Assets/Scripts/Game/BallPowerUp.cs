using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallPowerUp : MonoBehaviour
{
    [SerializeField] GameObject ball;

    [SerializeField] float downSpeed = -2f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(0, downSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Vector2 ballPos = new Vector2(transform.position.x, -2.77f);

            GameObject go = Instantiate(ball, ballPos, Quaternion.identity);
            go.GetComponent<Ball>().respawnPoint = ballPos;

            Destroy(gameObject);
        }
    }
}
