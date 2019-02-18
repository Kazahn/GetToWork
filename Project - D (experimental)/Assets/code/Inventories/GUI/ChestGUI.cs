using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGUI : MonoBehaviour {

    public bool drawInventory;

    public GUISkin guiSkin;

    public List<Inventory> chestInv = new List<Inventory>();

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnGUI()
    {
        if (drawInventory)
        {

        }
    }   

    public void GiveInventory(List<Inventory> i)
    {
        this.chestInv = i;
    }

}

[System.Serializable]
public class Slot
{

}