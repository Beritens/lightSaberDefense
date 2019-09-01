using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longSword : IPowerUp
{
    public GameObject normal;
    public GameObject longS;
    bool active = false;
    public powerUp pU;
    public Animator anim;
    public float animSpeed;
    public override void activate()
    {
        this.enabled = true;
        longS.SetActive(true);
        normal.SetActive(false);
        active = true;
    }

    public override void deactivate()
    {
        longS.SetActive(false);
        normal.SetActive(true);
        active = false;
        this.enabled = false;
    }
    void Update()
    {
        if(active){
            anim.SetFloat("time",pU.timer(animSpeed,0));
        }
    }
}
