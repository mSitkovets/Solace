using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {

	//delete the magic
	void Start () 
    {
        Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
