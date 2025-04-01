using UnityEngine;

public class Splitter : ComponentTile
{
    public override void OnPowerEnter(Vector2 fromDirection)
    {
        Glow();
        Vector2[] directions = new Vector2[] { Vector2.left, Vector2.right };

        foreach (Vector2 dir in directions)
        {
            PowerFlowTester.Instance.PropagateFrom(transform.position, dir);
        }
    }
}
