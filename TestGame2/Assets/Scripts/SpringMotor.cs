using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMotor : MonoBehaviour {
    public Rigidbody player;
    public float springForce;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.AddForce(Vector3.up * springForce);
        }
    }

}
