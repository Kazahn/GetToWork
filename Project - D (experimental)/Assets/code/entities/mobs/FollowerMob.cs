﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMob : Entity {

    public Entity following;
    public float distance;

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update() {
        if (following.GetComponent<Rigidbody2D>().transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x > (GetComponent<Rigidbody2D>().transform.position.x + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x < (GetComponent<Rigidbody2D>().transform.position.x - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (health <= 0) Die();
    }

    public void Die()
    {
        print("FollowerMob has been killed!");
    }
}

