using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementGenerator : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private Element[] _elements;
    [SerializeField] private Transform _parent;

    private WaitForFixedUpdate _waitForFixedUpdate;

    private void Awake() =>
        _waitForFixedUpdate = new WaitForFixedUpdate();

    public void Fill(IReadOnlyList<Cell> cells) =>
        StartCoroutine(GenerateElements(cells));

    private IEnumerator GenerateElements(IReadOnlyList<Cell> cells)
    {
        yield return _waitForFixedUpdate;

        foreach (Cell cell in cells)
            if (cell.Element == null)
                SetElement(cell);
    }

    private void SetElement(Cell cell)
    {
        int resourceIndex = Random.Range(0, _elements.Length);

        Element element = Instantiate(_elements[resourceIndex], cell.transform.position, Quaternion.identity, _parent);

        cell.Set(element);
    }
}