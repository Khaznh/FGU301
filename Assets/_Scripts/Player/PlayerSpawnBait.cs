using UnityEngine;

public class PlayerSpawnBait : MonoBehaviour
{
    [SerializeField] private GameObject baitPrefab;
    [SerializeField] private float spawnDistance = 1.0f;   

    public GameObject SpawnBait(Vector2 lastDir)
    {
        Vector3 spawnPos = transform.position + new Vector3(lastDir.x, lastDir.y,0) * spawnDistance;
        GameObject bait = Instantiate(baitPrefab, spawnPos, Quaternion.identity);
        bait.transform.parent = transform;
        return bait;
    }
}
