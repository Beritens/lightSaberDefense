using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gyroControl : MonoBehaviour
{
    public bool gEnabled;
    public powerUp powerUp;
	Gyroscope gyroscope;
    Rigidbody2D rb;
    Collider2D col;
    spawnBlood sB;
    public GameObject particles;
    public scoreStuff score;
    
    
	// Use this for initialization
	void Start () {
        
        sB = spawnBlood.instance;
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
		gEnabled = enableG();
        rb.centerOfMass = Vector2.zero;
	}
	bool enableG(){
		//if(SystemInfo.supportsGyroscope){
			gyroscope = Input.gyro;
			gyroscope.enabled = true;
			return true;
		//}
		//return false;
	}
	
	// Update is called once per frame
	void Update () {
        if(gEnabled){
            rb.MoveRotation(gyroscope.attitude);
        }
		    
	}
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "thing"){
            if(other.contacts[0].otherCollider == col){
                SceneManager.LoadScene("game");
            }
            else{
                // sB.splash(other.transform.position,0.5f,null,2);
                // sB.splash(other.contacts[0].point,0.25f,transform,1f);
                score.scoreUp();
                GameObject.Instantiate(particles,other.contacts[0].point,Quaternion.LookRotation(other.contacts[0].normal,-Vector3.forward));
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.GetComponent<powerUpThing>() != null){
            if(other.contacts[0].otherCollider == col){
                score.scoreUp();
                powerUpThing put = other.gameObject.GetComponent<powerUpThing>();
                powerUp.activate(put.index,powerUp.defaultPowerUpTime);
                Destroy(other.gameObject);
            }
            else{
                SceneManager.LoadScene("game");
            }
            
        }
        
    }
    
    private Quaternion zRotation(Quaternion q)
    {
        float theta = Mathf.Atan2(q.z, q.w);

        // quaternion representing rotation about the z axis
        return new Quaternion(0, 0, Mathf.Sin(theta), Mathf.Cos(theta));
    }
    private float zRotationA(Quaternion q)
    {
        Debug.Log(q);
        float theta = Mathf.Atan2(q.z, q.w);
        float angle = theta*Mathf.Rad2Deg*2;

        // quaternion representing rotation about the z axis
        return angle;
    }
}
