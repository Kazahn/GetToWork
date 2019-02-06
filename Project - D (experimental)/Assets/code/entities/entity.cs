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
    public void TakeHealth (int amount)
    {
        health -= amount;
    }

}
