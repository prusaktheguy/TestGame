using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMotor : MonoBehaviour {
    public Rigidbody player;
    public float springForce;
    // How much spring will go down after contact with player
    public float springMovementRange;
    // a variable for checking if first shoot happened and a need for cooldown before next shoot
    bool isFirstTimeShooted=false;
    //indicates that player should be shooted when spring reach lower limit
    bool shootMe = false;
    public float springMovementSpeed;
    float upperRangeLimit;
    float lowerRangeLimit;
    Rigidbody m_Rigidbody;


    // Use this for initialization
    void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        lowerRangeLimit = m_Rigidbody.position.y;
        upperRangeLimit = lowerRangeLimit + springMovementRange;
        m_Rigidbody.velocity = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update () {

        //check if shooting platform reached upper range limit, if it do, stop it's movement
        if (m_Rigidbody.velocity!=Vector3.zero && m_Rigidbody.position.y >= upperRangeLimit )
        {
            m_Rigidbody.velocity = Vector3.zero;
        }

        //check if shooting platform spring is loaded (if it reached it lower range limit), if it is then launch the platform
        if (m_Rigidbody.position.y < lowerRangeLimit && shootMe)
        {
            player.AddForce(Vector3.up * springForce);

            m_Rigidbody.AddForce(Vector3.up * springMovementSpeed);
            shootMe = false;
        }
	}
    void OnCollisionEnter(Collision col)
    {
        //check if collision of shooting platform with player occured
        if (col.gameObject.tag == "Player")
        {
            //First time shooting shall start immediately, otherwise indicate that platform should start loading
            if (!isFirstTimeShooted)
            {
                isFirstTimeShooted = true;
                player.AddForce(Vector3.up * springForce);

                m_Rigidbody.AddForce(Vector3.up * springMovementSpeed);

            }
            else
            {
                shootMe = true;

            }
        }
    }

}
