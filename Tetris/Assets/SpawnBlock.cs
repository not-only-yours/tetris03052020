using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject Next;
    
    void Start()
    {
        NewBlock(true);
    }

    
    public void NewBlock(bool first)
    {
        if (first)
        {
            Instantiate(Blocks[Random.Range(0, Blocks.Length)], transform.position, Quaternion.identity);
            ScoreScript.scoreValue += 10;
            Next = Blocks[Random.Range(0, Blocks.Length)];
        }
        else
        {
            Instantiate(Next, transform.position, Quaternion.identity);
            ScoreScript.scoreValue += 10;
            Next = Blocks[Random.Range(0, Blocks.Length)];
        }
    }
}
