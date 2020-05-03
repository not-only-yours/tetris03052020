using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMenu : MonoBehaviour
{
    
    public void GoToMenu()
    {
        ScoreScript.scoreValue = -10;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
