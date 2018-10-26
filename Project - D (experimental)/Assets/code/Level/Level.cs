using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {

    private int levelWidth;
    private int levelHeight;

    public Transform floorTile;
    public Transform wallTile;

    public Color floorColor;
    public Color wallColor;

    public Texture2D levelTexture;

    public Entity player;

	// Use this for initialization
	void Start () {
        levelWidth = levelTexture.width;
        levelHeight = levelTexture.height;

        Loadlevel ();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Loadlevel()
    {
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {

            }

        }
    }
    
}
