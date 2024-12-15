using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockCounter : MonoBehaviour
{
    public GameObject blockParent;

    GameObject levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = GameObject.Find("LevelLoader");

        InvokeRepeating("CheckWin", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckWin()
    {
        if (levelLoader.GetComponent<LevelLoader>().gameStarted)
        {
            if (blockParent.transform.childCount == 0)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }

}
