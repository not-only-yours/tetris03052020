using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
  bool isPaused = false;    // Pause button
  public void pausegame() 
  {
      if (isPaused)
      {
          Time.timeScale = 1;
          isPaused = false;
          GameObject.Find("PauseButton").GetComponentInChildren<Text>().text = "PAUSE";
          
        
      }
      else  
      {
           Time.timeScale = 0;
           isPaused = true;
          GameObject.Find("PauseButton").GetComponentInChildren<Text>().text = "UNPAUSE";
         
           
          
      }  
  }  
}
