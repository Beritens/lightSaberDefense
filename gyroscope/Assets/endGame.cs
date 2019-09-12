using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class endGame : MonoBehaviour
{
    public static endGame instance;
    public GameObject deathPanel;
    //bool ende = false;
    public TextMeshProUGUI oldScoreText;
    public TextMeshProUGUI oldHighScoreText;
    public TextMeshProUGUI newScoreText;
    public TextMeshProUGUI newHighScoreText;
    public GameObject extraLifeButton;
    public RectTransform playAgain;
    public spawn spawn;
    public powerUp pU;
    public gyroControl player;
    bool playing = false;
    public GameObject startThing;
    

    void Awake()
    {
        instance = this;
    }
    public void startGame()
    {
        pU.enabled = true;
        spawn.enabled = true;
        playing = true;
        startThing.SetActive(false);
    }
    public void end(){
        if(playing){
            deathPanel.SetActive(true);
            newScoreText.text = "Score: "+oldScoreText.text;
            newHighScoreText.text = "Score: "+oldHighScoreText.text;
            oldScoreText.gameObject.SetActive(false);
            oldHighScoreText.gameObject.SetActive(false);
            spawn.enabled = false;
            player.enabled = false;
            foreach (things item in FindObjectsOfType<things>())
            {
                GameObject.Instantiate(player.particles,item.transform.position,Quaternion.LookRotation(-item.transform.position,-Vector3.forward));
                Destroy(item.gameObject);
            }
            playing = false;
        }
        
    }
    public void reloadScene(){
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale*0.02f;
        SceneManager.LoadScene("game");
    }
    public void extraLife(){
        ads.instance.ShowAd(adStuff);
        
    }
    void adStuff(ShowResult result){
        switch(result){
            case ShowResult.Finished:
                playing = true;
                //ende = false;
                deathPanel.SetActive(false);
                oldScoreText.gameObject.SetActive(true);
                oldHighScoreText.gameObject.SetActive(true);
                spawn.enabled = true;
                player.enabled = true;
                extraLifeButton.SetActive(false);
                playAgain.position = extraLifeButton.GetComponent<RectTransform>().position;
                break;
            case ShowResult.Skipped:
                ads.instance.showFailMessage(false);
                break;
            case ShowResult.Failed:
                ads.instance.showFailMessage(true);
                break;

        }
    }
}
