using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {

    private int levelWidth;
    private int levelHeight;

    public Transform floorTile;
    public Transform wallTile;

    private Color[] tileColours;

    public Color floorColour;
    public Color wallColour;

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

        tileColours = new Color[levelWidth * levelHeight];
        tileColours = levelTexture.GetPixels();

        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {

                 if (tileColours [x*y * levelWidth] == floorColour)
                 {
                       Instantiate(floorTile, new Vector3(x, y), Quaternion.identity);
                 }


                 if (tileColours [x * y * levelHeight] == wallColour)
                 {
                       Instantiate(wallTile, new Vector3(x, y), Quaternion.identity);
                 }


            }

        }
    }
    
}
