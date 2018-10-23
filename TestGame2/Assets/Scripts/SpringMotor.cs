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
    public float velocity;
    float upperRangeLimit;
    public float lowerRangeLimit;
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

        if (m_Rigidbody.velocity!=Vector3.zero && m_Rigidbody.position.y >= upperRangeLimit )
        {
            m_Rigidbody.velocity = Vector3.zero;
        }
        if (m_Rigidbody.position.y < lowerRangeLimit && shootMe)
        {
            player.AddForce(Vector3.up * springForce);

            m_Rigidbody.AddForce(Vector3.up * springMovementSpeed);
            shootMe = false;
        }
        velocity = m_Rigidbody.velocity.y;
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {

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
