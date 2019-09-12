using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreStuff : MonoBehaviour
{
    public static scoreStuff instance;
    int score = 0;
    int highScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if(PlayerPrefs.HasKey("highscore")){
            highScore = PlayerPrefs.GetInt("highscore");
            highscoreText.text = highScore.ToString();
        }
        else{
            PlayerPrefs.SetInt("highscore",highScore);
        }
    }

    public void scoreUp(){
        score ++;
        scoreText.text = score.ToString();
        if(highScore<score){
            highScore = score;
            PlayerPrefs.SetInt("highscore",highScore);
            highscoreText.text = highScore.ToString();
        }
    }
}
