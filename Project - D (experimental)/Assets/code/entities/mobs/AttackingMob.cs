using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingMob : Entity {

    public GameObject attacking1;
    public Entity attacking;
    public int distance;

    private bool canAttack;

	void Start () {
        canAttack = true;

        if (attacking1 == null)
        {
            attacking1 = GameObject.FindGameObjectWithTag("Player");
            attacking = attacking1.GetComponent<Entity>();
        }

    }
	
	
	void Update () {
        
       
        
        if (attacking.GetComponent<Rigidbody2D>().transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x > (GetComponent<Rigidbody2D>().transform.position.x + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x < (GetComponent<Rigidbody2D>().transform.position.x - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        if (Vector2.Distance(GetComponent<Rigidbody2D>().transform.position, attacking.transform.position) <= distance && canAttack)
        {
            AttackEntity();
            StartCoroutine(WaitForAttack());
        }

    }

    public void AttackEntity()
    {
        int take = Random.Range(1, 20);
        attacking.TakeHealth(take);
    }
    IEnumerator WaitForAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(2);
        canAttack = true;
    }

    public void Die()
    {
        print("AttackingMob has been killed!");
    }
}
