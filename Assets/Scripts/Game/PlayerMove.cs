using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused && transform.position.x > -3.4f && transform.position.x < 3.37f)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
        }

        if(transform.position.x < -3.4f)
        {
            transform.position = new Vector2(-3.39f, transform.position.y);
        }

        if (transform.position.x > 3.37f)
        {
            transform.position = new Vector2(3.36f, transform.position.y);
        }

        if (paused && LevelLoader.Instance.gameStarted && Input.GetButtonDown("Fire1"))
        {
            paused = false;
        }
    }
}
