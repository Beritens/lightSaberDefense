using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    [System.Serializable]
    public struct group{
        public int[] powerUps;
    }
    [HideInInspector]
    public float[] times;
    bool[] bools;
    public IPowerUp[] powerUps;
    public group[] groups;
    public float defaultPowerUpTime;
    public float startTime = 10f;
    public void start()
    {
        times = new float[powerUps.Length];
        bools = new bool[powerUps.Length];
    }
    public void activateStartPowerUp(int index){
        activate(index,startTime);
    }
    public void activate(int index, float time){
        times[index]+= time;

    }
    public void deactivate(int index){
        powerUps[index].deactivate();
        times[index]= 0;
        bools[index]= false;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<times.Length;i++){
            if(times[i]>0){
                if(bools[i]== false){
                    bools[i] = true;
                    foreach (group group in groups)
                    {
                        if(group.powerUps.ArrContains(i)){
                            for(int j = 0; j<group.powerUps.Length; j++){
                                if(group.powerUps[j] != i && bools[group.powerUps[j]]){
                                    deactivate(group.powerUps[j]);
                                }
                            }
                        }
                    }
                    powerUps[i].activate();   
                }
                times[i]-= Time.deltaTime;
                if(times[i]<0){
                    deactivate(i);
                }
            }
        }
    }
    public float timer(float animSpeed, int index){
        return Mathf.Clamp(animSpeed-(2*times[index]*(animSpeed/defaultPowerUpTime)),0,animSpeed);
    }
}
