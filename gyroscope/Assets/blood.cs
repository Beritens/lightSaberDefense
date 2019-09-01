using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    public Sprite[] sprites;
    public Color g0;
    public Color g1;
    public Color s0;
    public Color s1;
    void Start()
    {
        SpriteRenderer sR = GetComponent<SpriteRenderer>();
        sR.sprite = sprites[Random.Range(0,sprites.Length)];
        if(transform.parent != null){
            sR.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            sR.sortingOrder = 101;
            sR.color = Color.Lerp(s0,s1,Random.Range(0f,1f));
        }
        else{
            sR.color = Color.Lerp(g0,g1,Random.Range(0f,1f));
        }
    }
}
