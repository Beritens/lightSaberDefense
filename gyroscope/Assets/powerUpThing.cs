using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpThing : MonoBehaviour
{
    public int index;
    public SpriteRenderer sR;
    public Sprite[] icons;
    void Start()
    {
        sR.sprite = icons[index];
    }
}
