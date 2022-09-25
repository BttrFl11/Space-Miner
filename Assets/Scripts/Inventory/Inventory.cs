using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private InventorySlot[] inventorySlots;

    public Inventory(InventorySlot[] slots)
    {
        inventorySlots = slots;
    }

    public InventorySlot GetEmptryInventorySlot(ItemSO itemToAdd)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.ItemSO == null || (slot.ItemSO == itemToAdd && slot.Count < itemToAdd.MaxStack))
                return slot;
        }

        return null;
    }

    public void AddItem(ItemSO item)
    {
        if (item != null)
        {
            InventorySlot emptySlot = GetEmptryInventorySlot(item);
            emptySlot.SetItemSO(item);
        }
    }
}
