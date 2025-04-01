using UnityEngine;

public class VoltageSystem : MonoBehaviour
{
    public static VoltageSystem Instance { get; private set; }

    [Header("Voltage Settings")]
    public float currentVoltage = 0f;
    public float minVoltage = 0f;
    public float maxVoltage = 10f;

    [Header("Safe Zone")]
    public float safeMin = 4f;
    public float safeMax = 6f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ResetVoltage(float startVoltage = 0f)
    {
        currentVoltage = startVoltage;
    }

    public void ModifyVoltage(float amount)
    {
        currentVoltage += amount;
        currentVoltage = Mathf.Clamp(currentVoltage, minVoltage, maxVoltage);
        Debug.Log($"Voltage changed by {amount}, new total: {currentVoltage}");
    }

    public bool IsVoltageSafe()
    {
        return currentVoltage >= safeMin && currentVoltage <= safeMax;
    }

    public bool IsOverloaded()
    {
        return currentVoltage > safeMax;
    }

    public bool IsUnderpowered()
    {
        return currentVoltage < safeMin;
    }
}
