using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ElementConnectionLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        ClearLine();
    }

    public void DrawLine(int index, Vector3 position)
    {
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(index, position);
    }

    public void ClearLinePart() => 
        _lineRenderer.positionCount--;

    public void ClearLine() => 
        _lineRenderer.positionCount = 0;
}
