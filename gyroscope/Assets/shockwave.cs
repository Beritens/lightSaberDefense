using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwave : MonoBehaviour
{
    public float startSize;
    public float realStartSize;
    public float q;
    CircleCollider2D col;
    public float endT;
    public float endT2;
    public GameObject particles;
    float t;
    public bool kill= false;
    public bool givePoints = true;
    scoreStuff sS;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        if(givePoints){
            sS = scoreStuff.instance;
        }
    }
    void Update()
    {
        if(t<endT){
            col.radius = Mathf.Max(startSize*Mathf.Pow(q,t),realStartSize);
            
        }
        else if(t>= endT2){
            if(kill)
                endGame.instance.end();
            Destroy(gameObject);
        }
        t+= Time.deltaTime;
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<things>()){
            GameObject.Instantiate(particles,other.transform.position,Quaternion.LookRotation(-other.transform.position.normalized,-Vector3.forward));
            if(givePoints){
                sS.scoreUp();
            }
            Destroy(other.gameObject);
        }
    }
}
