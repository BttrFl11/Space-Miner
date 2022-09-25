using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject[] storePages;

    private int storePage;

    private const int MAX_PAGES = 3;

    private int StorePage
    {
        get { return storePage; }
        set 
        {
            if (value < MAX_PAGES)
            {
                storePage = value;

                DisableAllPages();
                storePages[StorePage].SetActive(true);
            }
        }
    }

    private bool StoreActivity
    {
        get { return storePanel.activeSelf; }
        set { storePanel.SetActive(value); }
    }

    private void Start()
    {
        SetStoreActivity(false);
    }

    private void DisableAllPages()
    {
        foreach (var page in storePages)
            page.SetActive(false);
    }

    private void SetStoreActivity(bool active) => StoreActivity = active;

    public void OnMenuButton(int index)
    {
        StorePage = index;
    }

    public void OnStoreButton()
    {
        SetStoreActivity(!StoreActivity);
    }

    public void OnCloseStoreButton()
    {
        SetStoreActivity(false);
    }
}
