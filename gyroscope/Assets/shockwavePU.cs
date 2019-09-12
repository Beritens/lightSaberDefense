using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwavePU : IPowerUp
{
    public GameObject border;
    public GameObject shockwave;
    public powerUp pU;
    public GameObject theLight;
    public override void activate(){
        pU.times[3] =10000000000000;
        this.enabled = true;
        border.SetActive(true);
        theLight.SetActive(true);
    }
    public override void deactivate(){
        this.enabled = false;
        border.SetActive(false);
        theLight.SetActive(false);
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.touchCount>0){
            GameObject.Instantiate(shockwave,Vector3.zero,Quaternion.identity);
            pU.deactivate(3);
        }
    }
}
