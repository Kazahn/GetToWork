using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    private int levelWidth;
    private int levelHeight;

    public Transform floorTile;
    public Transform wallTile;
    public Transform enemy;

    private Color[] tileColours;

    public Color floorColour;
    public Color wallColour;
    public Color spawnPointColour;
    public Color enemyPointColour;

    public Texture2D levelTexture;

    public Entity Player;

    public Entity[] friendlyEntities;

    // Use this for initialization
    void Start()
    {
        levelWidth = levelTexture.width;
        levelHeight = levelTexture.height;



        Loadlevel();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void Loadlevel()
    {

        tileColours = new Color[levelWidth * levelHeight];
        tileColours = levelTexture.GetPixels();

        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {

                if (tileColours[x + y * levelWidth] == floorColour)
                {
                    Instantiate(floorTile, new Vector3(x, y), Quaternion.identity);
                }


                if (tileColours[x + y * levelHeight] == wallColour)
                {
                    Instantiate(wallTile, new Vector3(x, y), Quaternion.identity);
                }
                if (tileColours[x + y * levelHeight] == spawnPointColour)
                {
                    Instantiate(floorTile, new Vector3(x, y), Quaternion.identity);
                    Vector2 pos = new Vector2(x, y);
                    Player.transform.position = pos;
                    for (int i = 0; i < friendlyEntities.Length; i++)
                    {
                        Vector2 npos = pos;
                        npos.x += i + 1;
                        friendlyEntities[i].transform.position = npos;
                    }
                }
                if (tileColours[x + y * levelHeight] == enemyPointColour)
                {
                    Instantiate(floorTile, new Vector3(x, y), Quaternion.identity);
                    Instantiate(enemy, new Vector3(x, y), Quaternion.identity);

                }

            }

        }
    }
}

