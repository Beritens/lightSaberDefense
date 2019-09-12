using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class startGame : MonoBehaviour
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    public powerUp pU;
    bool touch = false;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        pU.start();
    }
    void Update()
    {
        if((Input.touchCount >0) && (Input.GetTouch(0).phase == TouchPhase.Began)){
            touch = true;
            if(EventSystem.current.currentSelectedGameObject == null){
                endGame.instance.startGame();
            }
            
        }
    }
}
