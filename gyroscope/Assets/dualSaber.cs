using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dualSaber : IPowerUp
{
    public Sprite normal;
    public Sprite dual;
    public SpriteRenderer SR;
    public GameObject normalObj;
    public GameObject dualObj;
    bool active = false;
    public powerUp pU;
    public Animator anim;
    public float animSpeed;
    
    public override void activate(){
        this.enabled = true;
        dualObj.SetActive(true);
        normalObj.SetActive(false);
        SR.sprite = dual;
        active = true;
    }
    public override void deactivate(){
        dualObj.SetActive(false);
        normalObj.SetActive(true);
        SR.sprite = normal;
        active = false;
        this.enabled = false;
    }
    void Update()
    {
        if(active){
            anim.SetFloat("time",pU.timer(animSpeed,1));
        }
    }

}
