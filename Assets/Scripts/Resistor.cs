using UnityEngine;

public class Resistor : ComponentTile
{
    public float voltageDrop = 1.0f;

    public override void OnPowerEnter(Vector2 fromDirection)
    {
        Glow();
        VoltageSystem.Instance.ModifyVoltage(-voltageDrop);
    }
}
