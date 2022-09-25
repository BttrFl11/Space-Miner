using System.Collections.Generic;
using UnityEngine;

public class SectorGroup : MonoBehaviour
{
    public List<Sector> sectors = new();

    private void Awake()
    {
        sectors.AddRange(GetComponentsInChildren<Sector>());
    }
}
