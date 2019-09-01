using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class things : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = -transform.position.normalized*speed;
        transform.up = transform.position.normalized;
    }
}
