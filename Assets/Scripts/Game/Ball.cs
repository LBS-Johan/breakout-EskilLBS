using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Movement Variables")]
    [SerializeField] float speed;
    public Vector2 startVector;
    public Vector2 respawnPoint = new Vector2(0, -4f);

    [Space]

    [Header("Player Stats")]
    [SerializeField] int damage;

    [Space]

    [Header("Other")]
    [SerializeField] bool respawn;

    [HideInInspector] public bool paused;
    Vector2 oldVelocity;

    private void Awake()
    {
        Debug.Log("Hej hej");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        BallCounter.Instance.currentBallAmount += 1;
        BallCounter.Instance.currentBalls.Add(gameObject);

        rb = GetComponent<Rigidbody2D>();
        transform.position = respawnPoint;
        if (!paused)
        {
            rb.velocity = startVector * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }

        if (Input.GetButtonDown("Fire1") && LevelLoader.Instance.gameStarted && paused)
        {
            paused = false;
            rb.velocity = startVector * speed;
        }

        if (respawn)
        {
            if (transform.position.y < -6)
            {
                PlayerHealth.Instance.TakeDamage(1);

                transform.position = respawnPoint;
                paused = true;

                oldVelocity = rb.velocity;
                rb.velocity = Vector2.zero;
            }         
        }
        
        if(!respawn && transform.position.y < -6)
        {
            BallCounter.Instance.currentBallAmount -= 1;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();

        if(collision.gameObject.tag == "Block")
        {
            collision.gameObject.GetComponent<Block>().TakeDamage(1);
        }
    }
}
