using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int wight = 10;
    private static Transform[,] grid = new Transform[wight, height];
  
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { 
                transform.position += new Vector3(-1, 0, 0);
        if (!ValidMove())
            transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
                transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }

            if (Time.time - previousTime >(Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
                transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position += new Vector3(0, 1, 0);
                AddToGrid();
                CheckLines();
                this.enabled = false;
                if (!EndGame()) 
                {

                   
                   
                    FindObjectOfType<SpawnBlock>().NewBlock(false);
                    FindObjectOfType<SpawnNextT>().ShowNext();
                    
                   
                }
                else
                {
                    Time.timeScale = 0;
                    Record();
                    Debug.Log( PlayerPrefs.GetInt("highScore"));

                }
            }
            previousTime = Time.time;
        }
    }

    void CheckLines()
    {
        for(int i=height-1;i>=0;i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                ScoreScript.scoreValue += 100;
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j=0;j<wight;j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < wight; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < wight; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            if (roundedX < 0 || roundedX >= wight || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }

    bool EndGame() {
        foreach (Transform children in transform)
        {
            int y = Mathf.RoundToInt(children.transform.position.y);
            if (y >= 18)
                return true;
               
        }    
        return false; 
   }

   void Record()
   {
       int myScore =  ScoreScript.scoreValue;
       if (PlayerPrefs.HasKey("highScore"))
       {
            if (PlayerPrefs.GetInt("highScore") < myScore)
            {

                PlayerPrefs.SetInt("highScore", myScore);
            }    
       }
       else
       {
           PlayerPrefs.SetInt("highScore", myScore);
       }
       

   }
    
        
}