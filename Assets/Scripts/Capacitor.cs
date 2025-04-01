using UnityEngine;

public class Capacitor : ComponentTile
{
    public float storedPower = 0f;
    public float maxStorage = 3f;

    public override void OnPowerEnter(Vector2 fromDirection)
    {
        if (storedPower < maxStorage)
        {
            storedPower++;
            Glow();
            Debug.Log("Capacitor storing power: " + storedPower);
        }
        else
        {
            Glow();
            VoltageSystem.Instance.ModifyVoltage(1.0f); // Discharge
            storedPower = 0f;
        }
    }
}
