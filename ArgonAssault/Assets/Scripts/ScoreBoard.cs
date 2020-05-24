using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
 
    int score = 0;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }
    
    public void scoreHit(int ScoreIncrease)
    {
        score = score + ScoreIncrease;
        scoreText.text = score.ToString();
    }
 
}
