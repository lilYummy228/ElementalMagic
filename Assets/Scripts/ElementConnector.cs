using System;
using System.Collections.Generic;
using UnityEngine;

public class ElementConnector : MonoBehaviour
{
    private List<Element> _selectedElements = new();
    private List<Cell> _cells = new();
    private Element _currentSelectedElement;
    private float _offset = 2f;
    private float _resizeValue = 1.2f;

    public event Action ElementsUnselected;

    public void Update()
    {
        if (Input.GetMouseButton(0))
            SelectElements();

        if (Input.GetMouseButtonUp(0))
            DeselectElements();
    }

    private void DeselectElements()
    {
        foreach (Element element in _selectedElements)
        {
            element.transform.localScale *= _resizeValue;

            if (_selectedElements.Count > 1)
                Destroy(element.gameObject);
        }

        _selectedElements.Clear();

        ElementsUnselected?.Invoke();
    }

    private void SelectElements()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit && hit.collider.gameObject.TryGetComponent(out Element element))
        {
            SelectFirstElement(element);

            SelectNearestElement(element);
        }
    }

    private void SelectFirstElement(Element element)
    {
        if (_selectedElements.Count == 0)
        {
            Select(element);

            _currentSelectedElement = _selectedElements[0];
        }
    }

    private void SelectNearestElement(Element element)
    {
        if (_selectedElements.Contains(element) == false && element.GetType() == _selectedElements[0].GetType())
        {
            if (Vector3.Distance(_currentSelectedElement.transform.position, element.transform.position) < _offset)
            {
                Select(element);

                _currentSelectedElement = element;
            }
        }
    }

    private void Select(Element element)
    {
        element.transform.localScale /= _resizeValue;

        _selectedElements.Add(element);
    }
}
