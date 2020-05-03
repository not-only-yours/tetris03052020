using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public string theme = "GeometryScene";
    public Button[] buttons;
    void Start() 
    { 
        if (PlayerPrefs.HasKey("highScore")) 
            GameObject.Find("RecordObj").GetComponentInChildren<Text>().text = "Current record: " + PlayerPrefs.GetInt("highScore");
    }
    public void PlayGame()
    {
        Debug.Log(theme);
        SceneManager.LoadScene(theme);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeTheme(Button button)
    {
       theme = button.name + "Scene"; 
       ButtonsGrey();
    }

    public void ButtonsGrey()
    {
        foreach (Button button in buttons)
        {
            var color = button.colors;
            color.normalColor = Color.grey;
            button.colors = color;
        }
    }

}
