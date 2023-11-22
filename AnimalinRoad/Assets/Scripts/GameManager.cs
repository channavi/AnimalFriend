using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool end;
    public bool ready;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject player;
    void Start()
    {
        end = false;
        ready = true;
        score = 0;
        scoreText.text = "Score : " + score.ToString();   
    }
    
    public void GameOver()
    {
        if (end == true) return;
        end = true;
    }

    public void GetScore()
    {
        score += 1;
    }
    void Update()
    {
        if(end == false)
            scoreText.text = "Score : " + score.ToString();
        else if(end ==true)
            scoreText.text = "GameOver";

    }
}
