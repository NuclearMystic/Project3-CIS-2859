using UnityEngine;

public abstract class ComponentTile : MonoBehaviour
{
    public abstract void OnPowerEnter(Vector2 fromDirection);

    public virtual void Glow()
    {
        // Default glow effect
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
