using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour 
{
    public Transform spawn; //where magic appears
    public float speed;
    public Rigidbody2D star;
    private movement movement;
    public Animator animator;

	private void Start()
	{
        movement = GetComponent<movement>();
        animator = GetComponent<Animator>();

	}
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            //makes magic appear at the right location
            Rigidbody2D instance = Instantiate(star, spawn.position, spawn.rotation);

            //changes direction of where magic is shot depending on the way the player is facing
            if(movement.isRight())
                instance.AddForce(new Vector3(1, 0, 0) * speed); //requires vector with certain magnitude
            else
                instance.AddForce(new Vector3(-1, 0, 0) * speed);
        }
	}
}
