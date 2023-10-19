using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] obj;
    public bool end;
    public bool ready;
    public int score;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        end = false;
        ready = true;
        score = 0;
        InvokeRepeating("MakeObj", 1.0f, 1.5f);
        scoreText.text = "Score : " + score.ToString();   
    }
    
    void MakeObj()
    {
        Instantiate(obj[Random.Range(0, obj.Length)],
            new Vector3(2f, 0f, -7f), Quaternion.identity);
    }

    public void GameOver()
    {
        if (end == true) return;
        end = true;
        CancelInvoke("MakeObj");
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
