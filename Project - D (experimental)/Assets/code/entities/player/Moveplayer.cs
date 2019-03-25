using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplayer : MonoBehaviour {
    /*
    public GameObject playerBody1;
    public Entity playerBody;*/
    private float speed = 5;
    new Rigidbody2D rigidbody2D;
    private Vector2 moveVelocity;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
       //playerBody1 = GameObject.FindGameObjectWithTag("Player");
        //playerBody = playerBody1.GetComponent<Entity>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 oldPos = this.transform.position;
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        /*float newX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float newY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        PlayerMove(oldPos, newX, newY);*/
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + moveVelocity * Time.fixedDeltaTime);
    }
    /*
    private void PlayerMove(Vector3 oldPos, float newX, float newY)
    {
        rigidbody2D.MovePosition(new Vector3(oldPos.x + newX, oldPos.y + newY, oldPos.z));
    }*/
}
