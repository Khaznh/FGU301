
using Unity.Cinemachine;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private CinemachineCamera cinemachineCamera;
    private GameObject player;

    private void Awake()
    {
        cinemachineCamera = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        Vector3 spawnPos = GameController.instance.playerPositionToSpawn;

        if (spawnPos == Vector3.zero)
            spawnPos = transform.position;

        if (player == null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
            cinemachineCamera.Follow = newPlayer.transform;
            return;
        }

        player.transform.position = spawnPos;        
        cinemachineCamera.Follow = player.transform;
    }
}
