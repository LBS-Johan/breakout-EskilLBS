using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelCreator : MonoBehaviour
{
    public GameObject currentBlock;

    public static LevelCreator Instance;

    [SerializeField] Transform levelParent;

    [Space]
    [Header("UI Components")]
    [SerializeField] Image currentBlockIcon;
    [SerializeField] TextMeshProUGUI currentBlockNameText;
    [SerializeField] TextMeshProUGUI currentBlockStatsText;

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
        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject())
        {
            PlaceBlock();
        }
    }

    void PlaceBlock()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(position.x >= -4.3f || position.x <= 4.3f)
        {
            if(position.y >= 0.4f || position.y <= 5f)
            {
                position = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y * 2) / 2);

                GameObject _block = Instantiate(currentBlock, position, Quaternion.identity);
                _block.transform.SetParent(levelParent);
            }
        }
        
    }

    public void SetCurrentBlock(GameObject newBlock)
    {
        currentBlock = newBlock;

        currentBlockIcon.color = currentBlock.GetComponent<SpriteRenderer>().color;
        currentBlockNameText.text = newBlock.name;
        currentBlockStatsText.text = "Health: " + newBlock.GetComponent<Block>().maxHealth; 
    }

    public void SaveScene(string sceneName)
    {
        string[] path = EditorSceneManager.GetActiveScene().path.Split(char.Parse("/"));
        path[path.Length - 1] = sceneName + path[path.Length - 1];
        Scene newLevelScene = SceneManager.CreateScene(sceneName);

        EditorSceneManager.MoveGameObjectToScene(levelParent.gameObject, newLevelScene);

        //EditorSceneManager.SaveScene(newLevelScene, string.Join("/", path));


        Debug.Log(string.Join("/", path));
    }
}
