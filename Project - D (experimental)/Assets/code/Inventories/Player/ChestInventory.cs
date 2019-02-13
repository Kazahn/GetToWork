using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventory : MonoBehaviour {

    public ItemManager iManager;

    public List<Inventory> chestInv = new List<Inventory>();

	
	void Start () {
		
	}
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
            openChest();
	}

    public void AddToItemInventory(int itemId, int amount) 
    {
        for (int i = 0; i < iManager.items.Count; i++)
        {
            if (iManager.items[i].itemTransform.GetComponent<Item>().id == itemId)
            {
                Inventory inv = new Inventory(iManager.items[i].itemTransform.GetComponent<Item>(), amount);
                chestInv.Add(inv);
            }
        }
    }

    public void openChest()
    {
        GetComponent<ChestGUI>().giveInventory(chestInv);
    }

}
