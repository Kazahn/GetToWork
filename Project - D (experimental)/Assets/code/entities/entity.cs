using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    public float speed = 5;
    
    private Rigidbody2D prb2d;
    


    void Start () {
        
        prb2d = GetComponent<Rigidbody2D>();
    }


    void Update () {

        prb2d.freezeRotation = true;

    }
}
