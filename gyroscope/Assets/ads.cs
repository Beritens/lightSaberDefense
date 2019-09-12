using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;
using UnityEngine.UI;

public class ads : MonoBehaviour
{
    public string fail = "failed to show ad";
    public string skipped = "ad was sipped";
    public RectTransform messageBox;
    public TextMeshProUGUI messageText;
    public static ads instance;
    void Start()
    {
        instance = this;
    }
    public void ShowAd(System.Action<ShowResult> s){
        if(Advertisement.IsReady()){
            Advertisement.Show("rewardedVideo",new ShowOptions{resultCallback = s});
        }
    }
    public void showFailMessage(bool b){
        if(b){
            messageText.text = fail;
        }
        else{
            messageText.text = skipped;
        }
        StartCoroutine(animMes());
    }
    public float animationLength;
    public Vector2 pos1;
    public Vector2 pos2;
    IEnumerator animMes(){
        float t = 0f;
        while(t<animationLength){
            t+= Time.deltaTime;
            messageBox.localPosition = Vector2.Lerp(pos1,pos2,t/animationLength);
            yield return null;

        }
        yield return new WaitForSeconds(3);
        t = 0f;
        while(t<animationLength){
            t+= Time.deltaTime;
            messageBox.localPosition = Vector2.Lerp(pos2,pos1,t/animationLength);
            yield return null;

        }
    }
}
