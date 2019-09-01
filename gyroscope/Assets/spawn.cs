using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 timeFrame;
    public float distance;
    public powerUp pU;
    public GameObject powerUpPrefab;
    public float powerUpChance = 0.1f;
    public float powerUpBeforeTime;
    public float powerUpAfterTime;
    float t= 2f;
    void spawnIt(Vector3 position){
        GameObject.Instantiate(prefab,position,Quaternion.identity);
    }
    void Update()
    {
        t-= Time.deltaTime;
        if(t<= 0){
            if(Random.Range(0f,1f)<powerUpChance){
                t=Random.Range(timeFrame.x,timeFrame.y)+powerUpAfterTime+powerUpBeforeTime;
                StartCoroutine(spawnPU());
            }
            else{
                t= Random.Range(timeFrame.x,timeFrame.y);
                Vector2 dir = Random.insideUnitCircle;
                Vector2 pos = dir.normalized*distance;
                spawnIt(new Vector3(pos.x,pos.y,prefab.transform.position.z));
            }
            
        }
    }
    IEnumerator spawnPU(){
        yield return new WaitForSeconds(powerUpBeforeTime);
        Vector2 dir = Random.insideUnitCircle;
        Vector2 pos = dir.normalized*distance;
        GameObject p = GameObject.Instantiate(powerUpPrefab,pos,Quaternion.identity);
        p.GetComponent<powerUpThing>().index = Random.Range(0,pU.powerUps.Length);
    }
}
