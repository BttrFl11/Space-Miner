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
