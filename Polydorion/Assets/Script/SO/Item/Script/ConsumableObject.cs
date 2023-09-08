using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="New Consumable Object", menuName = "Inventory System/ System/Items/Consumable")]
public class ConsumableObject : ItemObject
{
    public int restoreHealthVal;
    public int restoreManaVal;

    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
