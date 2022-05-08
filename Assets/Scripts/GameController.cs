using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private int totalScore;

    public Text scoreText;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int points){
        totalScore += points;

        scoreText.text = totalScore.ToString();
    }
}
