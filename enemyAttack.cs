using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyAttack : MonoBehaviour
{
    public int health = 100; //enemy health

    public float speed = 5;
    public Rigidbody2D enemy;

    //tells object scale, location, rotation
    public Transform platform;
    //access size of platform
    public Collider2D platformSize;
   
    bool goingLeft = true;

    public Transform spawn;
    public Transform spawn1;
    public Transform spawn2;
    public Rigidbody2D enemy1Drop;
    public Rigidbody2D enemy2Drop;
    public Rigidbody2D enemy3Drop;

    public bool isEasyEnemy; 

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //checking right bounds
        if(enemy.position.x + 1 > platform.position.x + (platformSize.bounds.size.x/2))
        {
            //Debug.Log("Going left");
            goingLeft = true;
        }
        //checking left bounds
        else if(enemy.position.x - 1 < platform.position.x - (platformSize.bounds.size.x / 2))
        {
            //Debug.Log("Going right");
            goingLeft = false;
        }

        //changing velocity direction
        if(goingLeft)
        {
            //Debug.Log("change vel left");
			enemy.velocity = new Vector2(-speed, enemy.velocity.y);
        }
        else
        {
            //Debug.Log("change vel right");
            enemy.velocity = new Vector2(speed, enemy.velocity.y);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Collider2D collider = collision.collider;
        //Debug.Log("CollisionEnter");

        if(collider.tag == "Star")
        {
            health -= 20;
            Destroy(collider.gameObject);
            print(message: "Enemy Health: " + health);
        }

        if (health <= 0 && isEasyEnemy)
        {
            //already connected to script so don't need to reference collider
            if(enemy.name == "Malus")
            {
                SceneManager.LoadScene(2);  
            }
            Destroy(gameObject);
            Rigidbody2D instance = Instantiate(enemy1Drop, spawn.position, spawn.rotation);
        }
        else if (health <= 0 && !isEasyEnemy)
        {
            Destroy(gameObject);
            Rigidbody2D instance = Instantiate(enemy1Drop, spawn.position, spawn.rotation);
            Rigidbody2D instance1 = Instantiate(enemy2Drop, spawn1.position, spawn1.rotation);
            Rigidbody2D instance2 = Instantiate(enemy3Drop, spawn2.position, spawn2.rotation);
        }
	}
}
