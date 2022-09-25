using UnityEngine;
using TMPro;

[System.Serializable]
public struct ItemDescription
{
    [Multiline(10)] public string text;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI nameText;
    public GameObject panel;
}
