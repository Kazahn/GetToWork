using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity {
    
    //new Rigidbody2D rigidbody2D;

   

    public ItemPlayerManager ipManager;

    void Start() { 
        ipManager.AddToItemInventory(0, 5);
       //rigidbody2D = GetComponent<Rigidbody2D>();
    }



    void Update()
    {


        /*Vector3 oldPos = this.transform.position;

        float newX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float newY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        PlayerMove(oldPos, newX, newY);

         if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
         {
             GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;

         }

         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
         {
             GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;

         }

         if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
         {
             GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;

         }

         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
         {
             GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;

         }*/
        
       /* if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            speed += 1;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            speed -= 1; 
        }*/

        

        if (health <= 0) Die();
    }
    /*private void PlayerMove(Vector3 oldPos, float newX, float newY)
    {
        rigidbody2D.MovePosition(new Vector3(oldPos.x + newX, oldPos.y + newY, oldPos.z));
       
    }
    */
    public void Die()
    {
        print("I've been killed!");
    }
}
