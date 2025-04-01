using UnityEngine;

public class StartNode : MonoBehaviour
{
    void Start()
    {
        PowerFlowTester tester = FindObjectOfType<PowerFlowTester>();
        if (tester != null)
        {
            Vector3 rightPos = transform.position + Vector3.right;
            tester.StartFlow(rightPos);
        }
    }
}
