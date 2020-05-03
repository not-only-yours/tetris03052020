using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnNextT : MonoBehaviour
{
    public GameObject NextT;
    
    void Start()
    {
        ShowNext();   
        Debug.Log("1"); 
    }

    public void ShowNext()
    {
        if (NextT != null)
        {
            DestroyImmediate(NextT, true);
            Debug.Log("7777"); 
        }
        NextT = Instantiate(FindObjectOfType<SpawnBlock>().Next, transform.position, Quaternion.identity);
        Debug.Log("1"); 
    }

}
