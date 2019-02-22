using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpriteSelector : MonoBehaviour
{
    public Sprite   spD, spL, spR, spU,
                    spDU, spLR, spRU, spLU, spDR, spDL,
                    spDLU, spLRU, spDRU, spDLR, spDLRU; //Names for every sprite, designated by their door locations.

    public bool down, left, right, up; //Room data for doors.
    public int type; //0: normal, 1: starter.

    public Color normalColor, enterColor; //Color for room types
    Color mainColor;
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        mainColor = normalColor;
        PickSprite();
        PickColor();
    }
    void PickSprite()
    {
        if(up)
        {
            if (down)
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spDLRU;
                    }
                    else
                    {
                        rend.sprite = spDRU;
                    }
                }
                else if (left)
                {
                    rend.sprite = spDLU;
                }
                else
                {
                    rend.sprite = spDU;
                }
            }
            else
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spLRU;
                    }
                    else
                    {
                        rend.sprite = spRU;
                    }
                }
                else if(left)
                {
                    rend.sprite = spLU;
                }
                else
                {
                    rend.sprite = spU;
                }
            }
            return;
        }
        if (down)
        {
            if (right)
            {
                if (left)
                {
                    rend.sprite = spDLR;
                }
                else
                {
                    rend.sprite = spDR;
                }
            }
            else if (left)
            {
                rend.sprite = spDL;
            }
            else
            {
                rend.sprite = spD;
            }
            return;
        }
        if (right)
        {
            if (left)
            {
                rend.sprite = spLR;
            }
            else
            {
                rend.sprite = spR;
            }
        }
        else
        {
            rend.sprite = spL;
        }
      }



    }
}

