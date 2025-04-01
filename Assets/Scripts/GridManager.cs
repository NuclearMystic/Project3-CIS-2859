using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject wirePrefab;
    public GameObject componentSlotPrefab;
    public GameObject disabledTilePrefab;
    public GameObject startNodePrefab;
    public GameObject targetNodePrefab;

    public float tileSize = 1f;

    // E = empty, W = wire, C = component, D = disabled, S = start, T = target/end
    private string[] levelLayout = new string[]
    {
        "E E E E E E",
        "E W W C D E",
        "S W E W T E",
        "E W W W E E",
        "E E E E E E"
    };

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int y = 0; y < levelLayout.Length; y++)
        {
            string[] row = levelLayout[y].Split(' ');

            for (int x = 0; x < row.Length; x++)
            {
                Vector3 spawnPos = new Vector3(x * tileSize, (levelLayout.Length - 1 - y) * tileSize, 0);
                string tileCode = row[x];

                switch (tileCode)
                {
                    case "W":
                        GameObject wire = Instantiate(wirePrefab, spawnPos, Quaternion.identity);

                        // Apply random rotation
                        int randRot = Random.Range(0, 4);
                        wire.transform.rotation = Quaternion.Euler(0f, 0f, -90f * randRot);

                        // Set internal state
                        WireTile wt = wire.GetComponent<WireTile>();
                        if (wt != null)
                        {
                            wt.rotation = (WireRotation)randRot;
                            wt.UpdateConnections(); // Make sure this method is public
                        }
                        break;

                    case "C":
                        Instantiate(componentSlotPrefab, spawnPos, Quaternion.identity);
                        break;

                    case "D":
                        Instantiate(disabledTilePrefab, spawnPos, Quaternion.identity);
                        break;

                    case "S":
                        Instantiate(startNodePrefab, spawnPos, Quaternion.identity);
                        break;

                    case "T":
                        Instantiate(targetNodePrefab, spawnPos, Quaternion.identity);
                        break;

                    case "E":
                    default:
                        // Skip or place background tile
                        break;
                }
            }
        }
    }

}
