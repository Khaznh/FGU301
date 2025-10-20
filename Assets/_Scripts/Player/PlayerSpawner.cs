
using Unity.Cinemachine;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private CinemachineCamera cinemachineCamera;

    private void Awake()
    {
        cinemachineCamera = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>();
    }

    void Start()
    {
        Vector3 spawnPos = GameController.instance.playerPositionToSpawn;

        if (spawnPos == Vector3.zero)
            spawnPos = transform.position;

        GameObject player = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        cinemachineCamera.Follow = player.transform;
    }
}
