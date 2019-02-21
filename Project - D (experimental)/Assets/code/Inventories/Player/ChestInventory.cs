using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventory : MonoBehaviour {

    public ItemManager iManager;

    public List<Inventory> chestInv = new List<Inventory>();

    public Entity checkingEntity;

    public bool CanOpen;

    public bool isOpen;

	
	void Start () {
		
	}
	
	
	void Update () {

        if (Vector2.Distance(GetComponent<Rigidbody2D>().transform.position, checkingEntity.GetComponent<Rigidbody2D>().transform.position) < 3)
            CanOpen = true;
        else
            CanOpen = false;
        if (CanOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
                ToggleChest();
            
        }
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

    public void ToggleChest()
    {
        if (!isOpen)
        {
            GetComponent<ChestGUI>().drawInventory = true;
            GetComponent<ChestGUI>().GiveInventory(chestInv);
        }
        else
            GetComponent<ChestGUI>().drawInventory = false;
        isOpen = !isOpen;

    }

}
