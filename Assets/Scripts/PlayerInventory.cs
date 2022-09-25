using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventoryPanel;

    private static Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(inventorySlots);

        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PickableItem pickableItem) && pickableItem.ItemSO != null)
        {
            if(inventory.GetEmptryInventorySlot(pickableItem.ItemSO) != null)
            {
                AddItem(pickableItem.ItemSO);
                Destroy(pickableItem.gameObject);
            }
        }
    }

    public void ToggleInventory()
    {
        bool active = inventoryPanel.activeSelf ? false : true;
        inventoryPanel.SetActive(active);
    }

    public void AddItem(ItemSO item)
    {
        inventory.AddItem(item);
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (var slot in inventorySlots)
        {
            bool active = slot.ItemSO != null;
            slot.gameObject.SetActive(active);
        }
    }
}
