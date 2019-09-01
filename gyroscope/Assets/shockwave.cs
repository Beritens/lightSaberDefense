using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwave : MonoBehaviour
{
    public float startSize;
    public float q;
    CircleCollider2D col;
    public float endT;
    public float endT2;
    public GameObject particles;
    float t;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if(t<endT){
            col.radius = startSize*Mathf.Pow(q,t);
            
        }
        else if(t>= endT2){
            endGame.instance.end();
            Destroy(gameObject);
        }
        t+= Time.deltaTime;
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yey");
        if(other.gameObject.GetComponent<things>()){
            GameObject.Instantiate(particles,other.transform.position,Quaternion.LookRotation(-other.transform.position.normalized,-Vector3.forward));
            Destroy(other.gameObject);
        }
    }
}
