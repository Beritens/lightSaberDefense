using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteShadow : MonoBehaviour
{
    public Vector3 offset = new Vector3(-0.5f,-0.5f,0.01f);
    public Material mat;
    public Color shadowColor;
    SpriteRenderer sprRndCaster;
    SpriteRenderer sprRndShadow;
    Transform transCaster;
    Transform transShadow;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        transCaster = transform;
        transShadow = new GameObject().transform;
        transShadow.parent = transCaster;
        transShadow.gameObject.name = "shadow";
        transShadow.localRotation = Quaternion.identity; 

        sprRndCaster = GetComponent<SpriteRenderer>();
        sprRndShadow = transShadow.gameObject.AddComponent<SpriteRenderer>();
        transShadow.localScale = Vector3.one;
        
        sprRndShadow.sortingLayerName = sprRndCaster.sortingLayerName;
        sprRndShadow.sortingOrder = sprRndCaster.sortingOrder-1;
        sprRndShadow.material = mat;
        sprRndShadow.material.color = shadowColor;
        
    }
    
    void LateUpdate()
    {
        transShadow.position = transCaster.position+offset;
        sprRndShadow.sprite = sprRndCaster.sprite;
    }
}
