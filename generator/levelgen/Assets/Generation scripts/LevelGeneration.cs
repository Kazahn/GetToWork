using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    Vector2 worldSize = new Vector2(4, 4); //Define level size in room-lengths (halfextents, actual size is twice this).
    Room[,] rooms; //Make 2D array of rooms.
    List<Vector2> takenPositions = new List<Vector2>(); //Keep a list of taken posistions in array for easier checkup using contains method.
    int gridSizeX, gridSizeY, numberOfRooms = 20; //Ints to keep track of max array size and number of rooms.
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

        CreateRooms(); //Calls script that creates the array and the rooms contained within.
        SetRoomDoors(); //Calls script that decides how many doors should be in a room.
        //DrawMap(); //Calls script that draws the map itself after calculating all the room info.
    }

    void CreateRooms()
    {
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];  //Sets room array to be proper size (REMEMBER; HALFEXTENTS).
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 1); //Places first room in the center of the array. Sets its roomtype as "1" - the starting room.
        takenPositions.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f; //GenInfo for Random Number Generation that'll effect how the generator decides where to place rooms.

        for (int i = 0; i < numberOfRooms - 1; i++) //Adds rooms to map. Keeps going as long as there are less than the max numberOfRooms. Takes into consideration the starting room.
        {
            float randomPerc = ((float)i) / (((float)numberOfRooms - 1)); //Checks how many rooms remain to be spawned.
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc); //Calculates odds for room placement location. Earlier generation stages branches more, builds on existing branches at later stages.

            checkPos = NewPosition(); //Checks any valid postion for a room to spawn.

            if (NumberOfNeighbors(checkPos, takenPositions) > 1 && Random.value > randomCompare) //Function that makes the map branch out more, without sacrificing compact level structure. Uses the GenInfo. As long as these criteria as met...
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
            x = (int)takenPositions[index].x; //Grabs a position at random that's already taken from the X axis.
            y = (int)takenPositions[index].y; //Grabs a position at random that's already taken from the Y axis.
            bool UpDown = (Random.value < 0.5f); //Decides if the next position should be north or south.
            bool positive = (Random.value < 0.5f); //Decides if the next position should be east or west.
            if (UpDown) //Checks the random "UpDown" value, if it is positive the new position will be over or under the taken position.
            {
                if (positive) //Checks the random "Positive" value, if it is positive the higher value on the Y axis for the position (up) will be used...
                {
                    y += 1;
                }
                else //...otherwise it'll use the lower Y axis value (down).
                {
                    y -= 1;
                }
            }
            else //Checks the random UpDown value, if it is negative (anything other than positive) the new position will be to the right or left of the taken position.
            {
                if (positive) //Checks the random "Positive" value, if it is positive the higher value on the X axis for the position (right) will be used...
                {
                    x += 1;
                }
                else //...otherwise it'll use the lower X axis value (left).
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y); //Checks if the generated position is taken or free.
        }
        while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY); //Makes sure the new position is within the boundries of the array.
        return checkingPos;
    }

    Vector2 SelectiveNewPosition() //alternative method for valid positions. Helps with level diversity, specifically "branching". Functions almost identically to the NewPosition function.
    {
        int index = 0, inc = 0;
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;
        do
        {
            inc = 0;
            do //makes sure the new room position ONLY has ONE neighbor
            {
                index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
                inc++;
            }
            while (NumberOfNeighbors(takenPositions[index], takenPositions) > 1 && inc < 100); //Keep checking for a new position as long as the function doesn't find a room with only one neighbor, to a maximum of 100 checks.
            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;
            bool UpDown = (Random.value < 0.5f); //This part funtions the same as the NewPosition method above.
            bool positive = (Random.value < 0.5f);
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
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        }
        while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        if (inc >= 100)
        {
            print("ERROR: Couldn't find positions with only one neighbor."); //If the first check cannot find a room with only one neighbor after 100 checks, print an error.
        }
        return checkingPos;
    }

    int NumberOfNeighbors(Vector2 checkingPos, List<Vector2> usedPositions) //Makes a note of how many neighbors a room has.
    {
        int ret = 0;
        if (usedPositions.Contains(checkingPos + Vector2.right)) //Checks for neighboring rooms to the right.
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.left)) //Checks for neighboring rooms to the left.
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.up)) //Checks for neighboring rooms to the top.
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.down)) //Checks for neighboring rooms to the bottom.
        {
            ret++;
        }
        return ret; //Adds the number of neighbors to the usedPositions list.
    }

    void SetRoomDoors() //After all of the rooms have been placed this will calculate where the doors in the rooms go.
    {
        for (int x = 0; x < ((gridSizeX * 2)); x++)
        {
            for (int y = 0; y < ((gridSizeY * 2)); y++) //This for-loop will (in combination with the previous one) check every cell in the array to determine if there is a room there.
            {
                if (rooms[x, y] == null) //If the examined cell has no room...
                {
                    continue; //Move on to the cell.
                }

                Vector2 gridPosition = new Vector2(x, y);
                if (y - 1 < 0) //Checks for rooms adjacent rooms to the bottom.
                {
                    rooms[x, y].doorBot = false;
                }
                else
                {
                    rooms[x, y].doorBot = (rooms[x, y - 1] != null);
                }
                if (y + 1 >= gridSizeY * 2) //Checks for rooms adjacent rooms to the top.
                {
                    rooms[x, y].doorTop = false;
                }
                else
                {
                    rooms[x, y].doorTop = (rooms[x, y + 1] != null);
                }
                if (x - 1 < 0) //Checks for rooms adjacent rooms to the left.
                {
                    rooms[x, y].doorLeft = false;
                }
                else
                {
                    rooms[x, y].doorLeft = (rooms[x - 1, y] != null);
                }
                if (x + 1 >= gridSizeX * 2) //Checks for rooms adjacent rooms to the right.
                {
                    rooms[x, y].doorRight = false;
                }
                else
                {
                    rooms[x, y].doorRight = (rooms[x + 1, y] != null);
                }
            }
        }
    }
}
