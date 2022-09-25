using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private Asteroid[] asteroids;
    [SerializeField] private Vector2Int asteroidCount;
    [SerializeField] private Sector sectorPrefab;
    [SerializeField] private new BoxCollider2D collider;

    private bool asteroidsSpawned = false;

    private static Transform asteroidParent;
    private static SectorGroup sectorGroup;

    private void Awake()
    {
        if(sectorGroup == null)
        {
            asteroidParent = GameObject.Find("_AsteroidParent").transform;
            sectorGroup = GetComponentInParent<SectorGroup>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Camera _) && asteroidsSpawned == false)
        {
            SpawnAsteroids();
            SpawnSectors();
        }
    }

    private void SpawnSectors()
    {
        Vector2[] vectors = { 
            new(transform.position.x + 200, transform.position.y),
            new(transform.position.x - 200, transform.position.y),
            new(transform.position.x, transform.position.y + 200),
            new(transform.position.x, transform.position.y - 200)};

        List<Vector2> spawnPos = new(vectors);

        foreach (var sector in sectorGroup.sectors)
            if(Vector2.Distance(transform.position, sector.transform.position) <= 200)
                spawnPos.Remove(sector.transform.position);

        foreach (var pos in spawnPos)
            SpawnSingleSector(pos);
    }

    private void SpawnSingleSector(Vector2 pos)
    {
        var sector = Instantiate(sectorPrefab, pos, Quaternion.identity, sectorGroup.transform);
        sectorGroup.sectors.Add(sector);
    }

    private void SpawnAsteroids()
    {
        int count = Random.Range(asteroidCount.x, asteroidCount.y);

        while (count > 0)
        {
            Asteroid randAsteroid = asteroids[Random.Range(0, asteroids.Length)];
            Vector3 randPos = new Vector2(Random.Range(collider.size.x, -collider.size.x), Random.Range(collider.size.y, -collider.size.y)) / 2;
            randPos += transform.position;

            SpawnSingleAsteroid(randAsteroid, randPos);

            count--;
        }

        asteroidsSpawned = true;
    }

    private void SpawnSingleAsteroid(Asteroid asteroid, Vector3 pos)
    {
        Instantiate(asteroid, pos, Quaternion.identity, asteroidParent);
    }
}
