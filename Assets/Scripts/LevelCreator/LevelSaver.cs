using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSaver : MonoBehaviour
{
    public SerializableList<BlockData> blockDatas;
    [SerializeField] GameObject levelParent;

    [SerializeField] TMP_InputField levelNameText;

    [SerializeField] List<GameObject> blockObjects;

    public void SaveLevel()
    {
        string levelName = levelNameText.text;

        for (int i = 0; i < levelParent.transform.childCount; i++)
        {
            BlockData currentBlock = new BlockData();
            currentBlock.xPos = levelParent.transform.GetChild(i).position.x;
            currentBlock.yPos = levelParent.transform.GetChild(i).position.y;
            currentBlock.ID = levelParent.transform.GetChild(i).GetComponent<Block>().blockID;
            currentBlock.scale = levelParent.transform.GetChild(i).localScale.x;

            blockDatas.list.Add(currentBlock);
        }

        string blockData = JsonUtility.ToJson(blockDatas);
        Debug.Log(blockDatas);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + levelName + ".json", blockData);
    }

    /*public void LoadLevel()
    {
        string levelName = "Test level"; // Temp name

        string levelDataText = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + levelName + ".json");

        blockDatas = JsonUtility.FromJson<SerializableList<BlockData>>(levelDataText);

        for (int i = 0; i < blockDatas.list.Count; i++)
        {
            Vector2 blockPos = new Vector2(blockDatas.list[i].xPos, blockDatas.list[i].yPos);

            GameObject go = Instantiate(blockObjects[blockDatas.list[i].ID], blockPos, Quaternion.identity);
            go.transform.localScale = new Vector2(blockDatas.list[i].scale, blockDatas.list[i].scale);

        }
    }*/
}

[System.Serializable]
public class SerializableList<T>
{
    public List<T> list;
}
