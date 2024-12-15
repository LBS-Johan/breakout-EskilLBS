using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public string levelName;

    public void SelectLevel()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel(levelName);
    }
}
