using UnityEngine;
using System.Linq;

public class Asteroid : Damageable
{
    [Header("Transform Randomaze")]
    [SerializeField] private Vector2 minScale;
    [SerializeField] private Vector2 maxScale;
    [SerializeField] private Vector2 massRange;

    [Header("Drop")]
    [SerializeField] private AsteroidMineral[] minerals;
    [SerializeField] private Vector2Int dropCount = new(2, 4);

    private new Rigidbody2D rigidbody;
    private static PlayerInventory playerInventory;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (playerInventory == null)
            playerInventory = FindObjectOfType<PlayerInventory>();

        RandomizeScale();
        SortMinerals();
    }

    private void RandomizeScale()
    {
        float scaleX = Random.Range(minScale.x, maxScale.y);
        float scaleY = Random.Range(minScale.y, maxScale.y);
        Vector3 scale = new(scaleX, scaleY, 1);

        float mass = Mathf.Lerp(massRange.x, massRange.y, (scaleX + scaleY) / 4);

        rigidbody.mass = mass;
        transform.localScale = scale;
    }

    protected override void Die()
    {
        int count = Random.Range(dropCount.x, dropCount.y);
        while (count > 0)
        {
            float rand = Random.Range(0f, 100f);
            for (int i = 0; i < minerals.Length; i++)
            {
                if (rand <= minerals[i].content)
                {
                    playerInventory.AddItem(minerals[i].mineral);
                    break;
                }

                rand -= minerals[i].content;
            }

            count--;
        }

        Destroy(gameObject);
    }

    [ContextMenu("Sort Minerals")]
    private void SortMinerals()
    {
        CalculateDropPercent();

        AsteroidMineral temp;
        for (int i = 0; i < minerals.Length; i++)
        {
            for (int j = 0; j < minerals.Length; j++)
            {
                if (minerals[i].content > minerals[j].content)
                {
                    temp = minerals[j];
                    minerals[j] = minerals[i];
                    minerals[i] = temp;
                }
            }
        }
    }

    private void CalculateDropPercent()
    {
        float content = 0;
        for (int i = 0; i < minerals.Length; i++)
            content += minerals[i].content;

        for (int i = 0; i < minerals.Length; i++)
        {
            float percent = minerals[i].content / content * 100f;
            minerals[i].content = percent;
        }
    }
}
