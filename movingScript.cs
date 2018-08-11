using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingScript : MonoBehaviour 
{
    public float speed;
    public float maxSpeed;
    private Rigidbody2D rigidbody;

    public int platformMaxX = 20;
    public int platformMinX = 14;
    Vector3 direction = Vector3.right;

	// Use this for initialization
	void Start () 
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        speed = maxSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        //so velocity changes and can be read in other class
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

        if (transform.position.x < platformMinX)
        {
            speed = maxSpeed;
        }
        else if (transform.position.x > platformMaxX)
        {
            speed = -maxSpeed;
        }
    }
}
