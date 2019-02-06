using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemManager : MonoBehaviour {

    public List<Items> items = new List<Items>();

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	
	void Update () {
		
	}
}

[System.Serializable]
public class Items
{
    public string itemName;
    public int id;
    public Transform itemTransform;
}