using UnityEngine;

public class ComponentSlotTile : MonoBehaviour
{
    public bool isOccupied = false;

    public bool PlaceComponent(GameObject componentPrefab)
    {
        if (isOccupied) return false;

        Instantiate(componentPrefab, transform.position, Quaternion.identity);
        isOccupied = true;
        return true;
    }
}
