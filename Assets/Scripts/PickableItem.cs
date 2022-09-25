using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private new SpriteRenderer renderer;

    public ItemSO ItemSO;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();

        InitializeItem(ItemSO);
    }

    public void InitializeItem(ItemSO itemSO)
    {
        if(itemSO != null)
        {
            ItemSO = itemSO;
            renderer.sprite = ItemSO.Icon;
        }
    }
}
