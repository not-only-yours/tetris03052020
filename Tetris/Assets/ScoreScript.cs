﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = -10;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();    
    }
    void Update()
    {
        if (scoreValue < 0)
            score.text = "Score: 0";
        else
            score.text = "Score: " + scoreValue;    
    }
}