using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingMob : Entity {

    public Entity attacking;
    public int distance;

	void Start () {
		
	}
	
	
	void Update () {
        /*
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
        */
        if (Vector2.Distance(GetComponent<Rigidbody2D>().transform.position, attacking.transform.position) <= distance)
        {

        }

    }

    public void Die()
    {

    }

    public void attackEntity()
    {
        
    }
}
