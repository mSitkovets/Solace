using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour 
{
    public int health = 100;

    public float maxSpeed = 10f;
    private Rigidbody2D rigidbody;
    public float jumpForce = 250f;
    private Animator animator;
    bool facingRight = true;

    bool isGrounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround; //layer for the ground

    //holds number of jumps
    int jumps = 0;

    public int numMagic = 0;

    private float currentSpeed = 0;

	// Use this for initialization
	void Start () 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        //creates a circle around the feet to check if it is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        float moveX = Input.GetAxis("Horizontal");
        //assign the absolute value of moveX to HSpeed
        animator.SetFloat("HSpeed", Mathf.Abs(moveX));

        //if going right and not facing right then flip player
        if(moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if(moveX < 0 && facingRight)
        {
            Flip();
        }
        //only change x velocity
        rigidbody.velocity = new Vector2(currentSpeed + moveX * maxSpeed, rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumps < 1)
        {
            //makes player jump
            rigidbody.AddForce(Vector2.up * jumpForce);
            jumps++;

        }
        //print(message: jumps);
        if (isGrounded)
        {
            jumps = 0;
        }
        //print(message: "Health: " + health);

	}

	private void Update()
	{
        //change animation
        animator.SetFloat("VSpeed", Mathf.Abs(rigidbody.velocity.y));
	}
	void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        //flip scale
        scale.x *= -1;
        //save change back into transform
        transform.localScale = scale;
    }

    //actualy bumping into an object
	private void OnCollisionEnter2D(Collision2D collision)
	{
        //what we have attached to an object
        Collider2D collider = collision.collider;

        //open invisible gate before Malus
        if(collider.gameObject.tag == "Gate" && numMagic >= 3)
        {
            collider.enabled = false; 
        }
            
        if (collider.gameObject.tag == "Gate2")
        {
            SceneManager.LoadScene(3);
        }

        if(collider.gameObject.tag == "Enemy")
        {
            health -= 20;
        }
        if(health <=0)
        {
            //change this later to minus a life
            Destroy(gameObject);

        }
        //print(message: health);
        //Debug.Log(collider.tag);

	}

    //if object is a trigger
	private void OnTriggerEnter2D(Collider2D collider)
	{
        if (collider.tag == "Power up")
        {
            health += 20;
            //collider needs to reference game object connected to it
            Destroy(collider.gameObject);
        }
        //adding health when enemy drops a heart
        if (collider.tag == "Half Health")
        {
            health += 10;
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Magic")
        {
            numMagic++;
            Destroy(collider.gameObject);
        }
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
        if(collision.collider.tag == "Moving Floor")
        {
            currentSpeed = collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        }
        else
        {
            currentSpeed = 0;
        }
	}
	public bool isRight()
    {
        return facingRight;
    }

    public float getHealth()
    {
        return health;
    }

    public int getMagic()
    {
        return numMagic;
    }
}
