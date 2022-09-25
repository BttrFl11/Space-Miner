using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Items/Item")]
public class ItemSO : ScriptableObject
{
    public Sprite Icon;
    public int MaxStack;
}
