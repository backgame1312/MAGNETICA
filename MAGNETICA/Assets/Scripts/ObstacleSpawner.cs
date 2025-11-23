using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [System.Serializable]
    public class TileArea
    {
        public string areaName;
        public int minX;               // X 최소
        public int maxX;               // X 최대
        public int fixedY;             // 고정 Y 좌표
        public int obstacleCount;      // 장애물 수
        public Tile[] obstacleTiles;   // 장애물 종류 배열
    }

    public Tilemap tilemap;
    public TileArea[] spawnAreas;

    private HashSet<Vector3Int> usedPositions = new HashSet<Vector3Int>();

    void Start()
    {
        SpawnTiles();
    }

    void SpawnTiles()
    {
        foreach (var area in spawnAreas)
        {
            for (int i = 0; i < area.obstacleCount; i++)
            {
                Vector3Int pos;

                // 중복 생성 방지
                int safety = 0;
                do
                {
                    int x = Random.Range(area.minX, area.maxX + 1);
                    pos = new Vector3Int(x, area.fixedY, 0);

                    safety++;
                    if (safety > 5000) break;
                }
                while (usedPositions.Contains(pos));

                usedPositions.Add(pos);

                // 랜덤 타일 선택
                Tile selectedTile = area.obstacleTiles[Random.Range(0, area.obstacleTiles.Length)];
                tilemap.SetTile(pos, selectedTile);
            }

            Debug.Log($"Spawned {area.obstacleCount} tiles at Y={area.fixedY} in area: {area.areaName}");
        }
    }
}
