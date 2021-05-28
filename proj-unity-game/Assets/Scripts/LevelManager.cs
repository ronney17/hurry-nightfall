using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> groundPieces;

    public GameObject firstGround;

    float borderSize;

    Transform refPosition;
    public int levelSize;

    string blockTag;

    // Start is called before the first frame update
    void Start()
    {
        refPosition = firstGround.transform;
        blockTag = firstGround.tag;
        calculateBound();
        groundPatchGenerator();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void groundPatchGenerator()
    {
        for (int i = 0; i < levelSize; i++)
        {

            GameObject block = groundPieces[Random.Range(0, groundPieces.Count)];
            if (block.tag == "jumpObstacle" && blockTag == "jumpObstacle")
            {
                while (block.tag == "jumpObstacle")
                {
                    block = groundPieces[Random.Range(0, groundPieces.Count - 1)];
                }
            }

            GameObject placingBlock = Instantiate(block, refPosition.position, Quaternion.identity);
            placingBlock.transform.position = new Vector3(placingBlock.transform.position.x, placingBlock.transform.position.y, placingBlock.transform.position.z + borderSize * 7 / 4);

            /* Código com o BUG
            refPosition.position = placingBlock.transform.position;*/

            // Código com BUG corrigido
            refPosition = placingBlock.transform;

            blockTag = placingBlock.tag;
        }
    }
    void calculateBound()
    {
        borderSize = firstGround.GetComponent<BoxCollider>().bounds.extents.z;
    }
}