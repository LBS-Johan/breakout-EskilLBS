using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    List<GameObject> blocks;

    [Header("Spawn Position Variables")]
    [Tooltip("The prefab of the block that will be spawned")]
    [SerializeField] GameObject block;

    [Tooltip("The dimensions of the area where blocks are spawned, i.e how many blocks. (5, 5) would mean 25 blocks.")]
    [SerializeField] Vector2 dimensions;

    [Tooltip("Should dimensions be randomized?")]
    [SerializeField] bool randomDimensions;

    [Tooltip("The max dimensions that can be randomized.")]
    [SerializeField] Vector2 maxRandomDimensions;

    [Tooltip("The minimum dimensions that can be randomized")]
    [SerializeField] Vector2 minRandomDimensions;

    [Tooltip("The starting point for the blocks, where the first one is spawned. Should be set to the top left position")]
    [SerializeField] Vector2 startPoint;

    [Tooltip("The spacing between the blocks on both axis.")]
    [SerializeField] Vector2 spacing;

    // Start is called before the first frame update
    void Start()
    {
        if (randomDimensions)
        {
            dimensions = new Vector2(Random.Range(minRandomDimensions.x, maxRandomDimensions.x), Random.Range(minRandomDimensions.y, maxRandomDimensions.y));
        }

        startPoint = new Vector2(-(dimensions.x / 2f - spacing.x / 2f) * spacing.x, 4.5f);

        for (int i = 0; i < dimensions.x; i++)
        {
            for (int j = 0; j < dimensions.y; j++)
            {
                Instantiate(block, new Vector3(startPoint.x + spacing.x * i, startPoint.y - spacing.y * j, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
