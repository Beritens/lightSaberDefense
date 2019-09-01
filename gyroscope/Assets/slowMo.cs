using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMo : IPowerUp
{
    bool active = false;
    public float slowDown;
    public powerUp pU;
    public Animator anim;
    public float animSpeed = 10f;
    public override void activate(){
        anim.SetBool("slowMo",true);
        this.enabled = true;
        pU.times[2] += 3;
        active = true;
        StartCoroutine(changeTime(Time.timeScale,slowDown,0.05f));
    }
    public override void deactivate(){
        active = false;
        StartCoroutine(changeTime(Time.timeScale,1,0.5f));
        anim.SetBool("slowMo",false);
        this.enabled = false;
    }
    IEnumerator changeTime(float from, float to, float time){
        float t = time;
        while(t>=0){
            t-= Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(to,from,t/time);
            Time.fixedDeltaTime = Time.timeScale*0.02f;
            yield return null;
        }
        Time.timeScale = to;
        Time.fixedDeltaTime = Time.timeScale*0.02f;
    }
    void Update()
    {
        if(active){
            anim.SetFloat("time",pU.timer(animSpeed,2));
        }
    }
}
