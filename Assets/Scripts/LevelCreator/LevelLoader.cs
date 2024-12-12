using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] bool premadeLevel;

    [SerializeField] List<string> levelNames;

    SerializableList<BlockData> blockDatas;

    [SerializeField] List<GameObject> blockObjects;

    [SerializeField] GameObject levelSelectObject;
    [SerializeField] Transform levelSelectObjectParent;

    [SerializeField] GameObject levelSelectUI;

    public static LevelLoader Instance;
    public bool gameStarted = false;

    [SerializeField] TextMeshProUGUI countdownText;

    [SerializeField] Transform blockParent;

    private void Awake()
    {
        GameObject.Find("Ball").GetComponent<Ball>().paused = true;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        
    }

    private void Start()
    {
        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] infoFiles = info.GetFiles();

        for (int i = 0; i < infoFiles.Length; i++)
        {
            string fileName = infoFiles[i].Name;
            fileName = fileName.Replace(".json", "");

            GameObject go = Instantiate(levelSelectObject, transform.position, Quaternion.identity);
            go.transform.SetParent(levelSelectObjectParent);
            go.GetComponentInChildren<TextMeshProUGUI>().text = fileName;
            go.GetComponent<LevelSelectButton>().levelName = fileName;
        }

        
        GameObject.Find("Player").GetComponent<PlayerMove>().paused = true;
        Time.timeScale = 0;

        if (premadeLevel)
        {
            StartCoroutine(nameof(StartGameCountdown));
        }
    }

    public void LoadLevel(string levelName)
    {
        levelName = levelName.Replace(".json", "");
        string levelDataText = File.ReadAllText(Application.persistentDataPath + "/" + levelName + ".json");

        blockDatas = JsonUtility.FromJson<SerializableList<BlockData>>(levelDataText);

        for (int i = 0; i < blockDatas.list.Count; i++)
        {
            Vector2 blockPos = new Vector2(blockDatas.list[i].xPos, blockDatas.list[i].yPos);

            GameObject go = Instantiate(blockObjects[blockDatas.list[i].ID], blockPos, Quaternion.identity);
            go.transform.SetParent(blockParent);
            go.transform.localScale = new Vector2(blockDatas.list[i].scale, blockDatas.list[i].scale * 0.5f);
        }

        levelSelectUI.SetActive(false);

        StartCoroutine(nameof(StartGameCountdown));
    }

    public void LoadPremadeLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    IEnumerator StartGameCountdown()
    {
        Time.timeScale = 1;

        countdownText.text = "3";

        yield return new WaitForSeconds(1f);

        countdownText.text = "2";

        yield return new WaitForSeconds(1f);

        countdownText.text = "1";

        yield return new WaitForSeconds(1f);

        countdownText.text = "Start!";

        
        gameStarted = true;

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }
}
