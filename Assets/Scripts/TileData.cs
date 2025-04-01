using UnityEngine;

public enum TileType { Empty, Wire, ComponentSlot, Disabled }

public class TileData : MonoBehaviour
{
    public TileType tileType;
    public Vector2Int gridPosition;
}