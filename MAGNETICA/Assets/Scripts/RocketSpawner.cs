using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform player;
    public float spawnInterval = 2f;
    public float distanceX = 50f;
    public float spawnY = 0f;

    private PlayerController playerController;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRocket), 1f, spawnInterval);
    }

    void SpawnRocket()
    {
        if (player == null) return;

        if (playerController.currentPolarity != Polarity.N) return;

        Vector3 spawnPos = new Vector3(
            player.position.x + distanceX,
            spawnY,
            0f
        );

        Instantiate(rocketPrefab, spawnPos, rocketPrefab.transform.rotation);
    }
}
