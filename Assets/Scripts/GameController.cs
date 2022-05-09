using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private int totalScore;

    public Text scoreText;

    public GameObject gameOver;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        instance = this;
    }

    public void updateScore(int points){
        totalScore += points;

        scoreText.text = totalScore.ToString();
    }

    public void showGameOver(){
        gameOver.SetActive(true);
    }

    public void restartGame(string lvlName){
        SceneManager.LoadScene(lvlName);
    }
}
