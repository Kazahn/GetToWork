using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    Vector2 worldSize = new Vector2(4, 4); //Define level size in room-lengths (halfextents, actual size is twice this).
    Room[,] rooms; //Make 2D array of rooms.
    List<Vector2> takenPositions = new List<Vector2>(); //Keep a list of taken posistions in array for easier checkup using contains method.
    int gridSizeX, gridSizeY, numberOfRooms = 20; //Ints to keep track of max array size and number of rooms
    public GameObject roomWhiteObj;
    
    //Start is called before the first frame update.
    void Start()
    {
        if (numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2)) //If the numberOfRooms is more than the array can fit...
        {
            numberOfRooms = Mathf.RoundToInt((worldSize.x * 2) * (worldSize.y * 2)); //...change the numberOfRooms to fit the maximum.
        }
        gridSizeX = Mathf.RoundToInt(worldSize.x); 
        gridSizeY = Mathf.RoundToInt(worldSize.y); //Failsafes for consistency so that the array doesn't change.

        CreateRooms(); 
        SetRoomDoors();
        DrawMap(); //Calling scripts that handles room properties for generation of a map image.
    }

    void CreateRooms()
    {
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];  //Sets room array to be proper size (REMEMBER; HALFEXTENTS).
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 1); //Places first room in the center of the array. Sets its roomtype as "1" - the starting room.
        takenPositions.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f; //GenInfo for Random Number Generation that'll effect how the generator decides where to place rooms.

        for (int i=0; i < numberOfRooms - 1; i++) //Adds rooms to map. Keeps going as long as there are less than the max numberOfRooms. Takes into consideration the starting room.
        {
            float randomPerc = ((float) i) / (((float)numberOfRooms - 1)); //Checks how many rooms remain to be spawned.
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc); //Calculates odds for room placement location. Earlier generation stages branches more, builds on existing branches at later stages.

            checkPos = NewPosition(); //Checks any valid postion for a room to spawn.

            if (NumberOfNeighbors(checkPos,takenPositions) > 1 && Random.value > randomCompare) //Function that makes the map branch out more, without sacrificing all compact level structure. Uses the GenInfo. As long as these criteria as met...
            {
                int iterations = 0; //...set iterations to 0...
                do
                {
                    checkPos = SelectiveNewPosition(); //...and find a position with only one neighboring room.
                    iterations++;
                }
                while (NumberOfNeighbors(checkPos, takenPositions) > 1 && iterations < 100);
                if (iterations >= 50)
                    print("ERROR: Could not create wiht fewer neighbors than : " + NumberOfNeighbors(checkPos, takenPositions));
            }
            rooms[(int)checkPos.x + gridSizeX, (int)checkPos.y + gridSizeY] = new Room(checkPos, 0); //Takes the offset of the array into consideration, sets the roomtype to "0" - a normal room, saves the position info of a created room...
            takenPositions.Insert(0, checkPos); //...and adds it to the list of taken positions.
        }

    }

    Vector2 NewPosition() //Function that calculates and designates what makes a position valid beore spawning a room there. In this case; any position that neighboors an existing room, while still being within the array.
    {
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;

        do
        {
            int index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1)); 
            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y; //Grabs a position at random that's already taken.
            bool UpDown = (Random.value < 0.5f); 
            bool positive = (Random.value < 0.5f); //Decides what cardinal direction to generate the next position.
            if (UpDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y); //Checks if the generated position is taken or free.
        }
        while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY); //Makes sure the new position is within the boundries of the array.
        return checkingPos;
    }



    // Update is called once per frame.
    void Update()
    {
        
    }
}
