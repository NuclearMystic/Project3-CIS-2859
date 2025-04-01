using UnityEngine;
using System.Collections.Generic;

public class PowerFlowTester : MonoBehaviour
{
    public float checkDistance = 1.1f;
    private HashSet<WireTile> visited = new HashSet<WireTile>();

    public void StartFlow(Vector3 startPosition)
    {
        Debug.Log("Flow Started");
        visited.Clear();

        WireTile startingWire = GetWireAtPosition(startPosition);
        if (startingWire != null)
        {
            FlowPower(startingWire);
        }
    }

    void FlowPower(WireTile current)
    {
        if (visited.Contains(current)) return;

        visited.Add(current);
        current.GetComponent<SpriteRenderer>().color = Color.green; // Highlight

        foreach (WireTile neighbor in FindConnectedNeighbors(current))
        {
            FlowPower(neighbor);
        }
    }

    List<WireTile> FindConnectedNeighbors(WireTile tile)
    {
        List<WireTile> neighbors = new List<WireTile>();
        Vector2 pos = tile.transform.position;

        TryAdd(pos + Vector2.up, tile.connectsUp, t => t.connectsDown, neighbors);
        TryAdd(pos + Vector2.down, tile.connectsDown, t => t.connectsUp, neighbors);
        TryAdd(pos + Vector2.left, tile.connectsLeft, t => t.connectsRight, neighbors);
        TryAdd(pos + Vector2.right, tile.connectsRight, t => t.connectsLeft, neighbors);

        return neighbors;
    }

    void TryAdd(Vector2 position, bool fromConnects, System.Func<WireTile, bool> toConnects, List<WireTile> list)
    {
        if (!fromConnects) return;

        WireTile neighbor = GetWireAtPosition(position);
        if (neighbor != null && toConnects(neighbor))
        {
            list.Add(neighbor);
        }
    }

    WireTile GetWireAtPosition(Vector2 position)
    {
        Debug.Log("Checking for wire at: " + position);

        Collider2D hit = Physics2D.OverlapPoint(position);
        if (hit != null)
        {
            return hit.GetComponent<WireTile>();
        }
        return null;
    }
}
