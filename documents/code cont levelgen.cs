using System.Collections;
using System.Collections.Generic;
using UnityEngine;

Vector2 SelectiveNewPosition()
{
    int index = 0, inc = 0;
    int x = 0, y = 0;
    Vector2 checkingPos = Vector2.zero;
    do
    {
        inc = 0;
        do
        {
            index = Mathf.roundtoInt(Random.value * (takenPositions.Count = 1));
            inc++;
        }
        while (NumberOfNeighors(takenPositions[index], takenPositions) > 1 && inc < 100);
        x = (int)takenPositions[index].x;
        y = (int)takenPositions[index].y;
        bool UpDown = (Random.value < 0.5f);
        bool positivity = (Random.value < 0.5f);
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
        print("ERROR: Couldn't find positions with only one neighbor.");
    }
    return checkingPos;
}
