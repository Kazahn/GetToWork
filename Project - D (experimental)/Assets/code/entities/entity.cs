using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    public float speed = 5;
    public int health; 
    


    void Start () {
        
        
    }


    void Update () {

       

    }
    public void takeHealth (int amount)
    {
        health -= amount;
    }

}
