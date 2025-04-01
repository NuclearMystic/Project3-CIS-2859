using UnityEngine;

public enum WireRotation
{
    Up,
    Right,
    Down,
    Left
}

public class WireTile : MonoBehaviour
{
    public WireRotation rotation = WireRotation.Up;

    // defines which directions are available per tile
    public bool connectsUp, connectsRight, connectsDown, connectsLeft;

    private void Start()
    {
        UpdateConnections();
    }

    private void OnMouseDown()
    {
        RotateClockwise();
    }

    public void RotateClockwise()
    {
        rotation = (WireRotation)(((int)rotation + 1) % 4);
        transform.Rotate(0f, 0f, -90f);
        UpdateConnections();
    }

    public void UpdateConnections()
    {

        switch (rotation)
        {
            case WireRotation.Up:
                SetConnections(true, false, true, false); break;
            case WireRotation.Right:
                SetConnections(false, true, false, true); break;
            case WireRotation.Down:
                SetConnections(true, false, true, false); break;
            case WireRotation.Left:
                SetConnections(false, true, false, true); break;
        }
    }

    private void SetConnections(bool up, bool right, bool down, bool left)
    {
        connectsUp = up;
        connectsRight = right;
        connectsDown = down;
        connectsLeft = left;
    }
}
