using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBlood : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blood;
    public static spawnBlood instance;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Awake()
    {
        instance = this;
    }
    public void splash(Vector2 pos, float spread, Transform parent, float scale){
        GameObject g = GameObject.Instantiate(blood,pos+Random.insideUnitCircle*spread, Quaternion.Euler(0,0,Random.Range(0f,360f)));
        if(parent != null){
            g.transform.parent = parent;
        }
        g.transform.localScale *= scale;
    }
}
