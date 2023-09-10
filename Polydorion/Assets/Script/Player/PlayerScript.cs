using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            inventory.AddItem(new Item (item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            inventory.Save();
        }

        if(Input.GetKeyDown(KeyCode.F8))
        {
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear();
    }
}
