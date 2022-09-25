using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ItemDescription itemDescription;
    [SerializeField] private float descriptionTimer = 0.5f;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI countText;

    private bool showDescription = false;

    public int Count { get; private set; }
    public ItemSO ItemSO { get; private set; }

    public void SetItemSO(ItemSO itemSO)
    {
        ItemSO = itemSO;
        Count++;

        UpdateUI();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        showDescription = true;

        StartCoroutine(ShowDescription());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        showDescription = false;

        StopCoroutine(ShowDescription());

        SetDescriptionActivity(false);
    }

    private IEnumerator ShowDescription()
    {
        yield return new WaitForSeconds(descriptionTimer);

        if (showDescription)
            SetDescriptionActivity(true);
    }

    private void SetDescriptionActivity(bool active) => itemDescription.panel.SetActive(active);

    private void UpdateUI()
    {
        itemDescription.nameText.text = ItemSO.name;
        itemIcon.sprite = ItemSO.Icon;
        countText.text = Count.ToString();
    }
}
