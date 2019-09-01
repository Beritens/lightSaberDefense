using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public static endGame instance;
    void Awake()
    {
        instance = this;
    }
    public void end(){
        SceneManager.LoadScene("game");
    }
}
