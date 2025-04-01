using UnityEngine;

public class Mirror : ComponentTile
{
    public Vector2 redirectFrom = Vector2.left;
    public Vector2 redirectTo = Vector2.up;

    public override void OnPowerEnter(Vector2 fromDirection)
    {
        Glow();

        if (fromDirection == redirectFrom)
        {
            PowerFlowTester.Instance.PropagateFrom(transform.position, redirectTo);
        }
    }
}
