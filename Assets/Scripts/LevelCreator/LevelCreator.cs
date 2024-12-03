using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelCreator : MonoBehaviour
{
    public GameObject currentBlock;

    public static LevelCreator Instance;

    [SerializeField] Transform levelParent;

    [Range(0.5f, 1f)]
    public float scale;
    [SerializeField] TextMeshProUGUI scaleText;
    [SerializeField] GameObject previewBlock;

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
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject())
        {
            PlaceBlock();
        }

        if (mousePosition.x >= -4.3f || mousePosition.x <= 4.3f)
        {
            if (mousePosition.y >= 0.4f || mousePosition.y <= 5f)
            {
                previewBlock.SetActive(true);
                mousePosition = new Vector2(Mathf.Round(mousePosition.x / scale) * scale, Mathf.Round(mousePosition.y * 2 / scale) / 2 * scale);
                previewBlock.transform.position = mousePosition;
                previewBlock.transform.localScale = new Vector2(scale * 0.9f, scale * 0.45f);
            }
            else
            {
                previewBlock.SetActive(false);
            }
        }
        else
        {
            previewBlock.SetActive(false);
        }
    }
    void PlaceBlock()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(position.x >= -4.3f || position.x <= 4.3f)
        {
            if(position.y >= 0.4f || position.y <= 5f)
            {
                position = new Vector2(Mathf.Round(position.x / scale) * scale, Mathf.Round(position.y * 2 / scale) / 2 * scale);

                GameObject _block = Instantiate(currentBlock, position, Quaternion.identity);
                _block.transform.SetParent(levelParent);
                _block.transform.localScale = new Vector2(scale * 0.9f, scale * 0.45f);
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

    public void SetScale(float newScale)
    {
        scale = newScale;

        scaleText.text = "Scale: " + Mathf.Round(scale * 100) + "%";
    }
}
