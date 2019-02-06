using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlayerManager : MonoBehaviour {

    public ItemManager iManager;


    public List<Items> items = new List<Items>();

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void AddToItemInventory(int itemId)
    {
        for(int i = 0; i < iManager.items.Count; i++)
        {
            if(iManager.items[i].itemTransform.GetComponent<Items>().id == itemId)
            {
                items.Add(iManager.items[i].itemTransform.GetComponent<Items>());
            }
        }
    }
}
