using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    [HideInInspector] public List<GameObject> currentBalls;
    [HideInInspector] public int currentBallCount = 1;
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
