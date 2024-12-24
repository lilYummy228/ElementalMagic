using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(LineAnimator))]
public class ElementConnectionLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private LineAnimator _lineAnimator;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineAnimator = GetComponent<LineAnimator>();

        ClearLine();
    }

    private void Update() => 
        _lineAnimator.Animate(_lineRenderer);

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
