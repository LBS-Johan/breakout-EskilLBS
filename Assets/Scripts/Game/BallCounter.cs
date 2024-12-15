using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCounter : MonoBehaviour
{
    [HideInInspector] public List<GameObject> currentBalls;
    [HideInInspector] public int currentBallAmount = 0;
    public static BallCounter Instance;

    [SerializeField] GameObject ballPrefab;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        Debug.Log(currentBallAmount);

        if (currentBallAmount <= 0)
        {
            

            SceneManager.LoadScene("MainMenu");
        }
    }

    public void DuplicateBalls()
    {
        int ballCount = currentBalls.Count;

        for (int i = 0; i < ballCount; i++)
        {
            for (int j  = 0; j < 2; j++)
            {
                Instantiate(ballPrefab, currentBalls[i].transform.position, Quaternion.identity);
                currentBalls[i].GetComponent<Ball>().startVector = currentBalls[i].GetComponent<Rigidbody2D>().velocity;
            }
        }

        foreach (GameObject ball in currentBalls)
        {
            
        }
    }
}
