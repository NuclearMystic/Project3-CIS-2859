using UnityEngine;

public class WireSpawner : MonoBehaviour
{
    public GameObject wireTilePrefab;
    public int width = 6;
    public int height = 6;
    public float tileSize = 1f;

    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 position = new Vector3(x * tileSize, y * tileSize, 0);
                Instantiate(wireTilePrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
