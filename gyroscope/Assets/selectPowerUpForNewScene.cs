using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class selectPowerUpForNewScene : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject button;
    public powerUp pU;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject g = GameObject.Instantiate(button,Vector2.zero,Quaternion.identity,transform);
            Button b = g.GetComponent<Button>();
            g.GetComponent<Image>().sprite = sprites[i];
            int x = new int();
            x = i;
            b.onClick.AddListener(delegate{pUbNS(x);});
            
        }
    }
    int x = -1;

    void pUbNS(int i){
        x= i;
        ads.instance.ShowAd(adStuff);
        
    }
    void adStuff(ShowResult result){
        switch(result){
            case ShowResult.Finished:
                pU.activateStartPowerUp(x);
                endGame.instance.startGame();
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
