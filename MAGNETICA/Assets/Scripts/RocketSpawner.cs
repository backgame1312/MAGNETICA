using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform player;      // 플레이어 Transform 참조
    public float spawnInterval = 2f;
    public float distanceX = 50f; // 플레이어 기준 X 거리

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRocket), 1f, spawnInterval);
    }

    void SpawnRocket()
    {
        if (player == null) return;

        // 플레이어 y 그대로, x는 +distanceX
        Vector3 spawnPos = new Vector3(player.position.x + distanceX, player.position.y, 0);

        Instantiate(rocketPrefab, spawnPos, Quaternion.identity);
    }
}
