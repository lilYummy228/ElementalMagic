using System;
using System.Collections.Generic;
using UnityEngine;

public class ElementConnector : MonoBehaviour
{
    private const float Distance = 1.5f;

    [SerializeField] private ElementConnectionLine _connectionLine;

    private List<Element> _selectedElements = new();
    private Element _currentSelectedElement;

    public event Action ElementsPopped;
    public event Action<int> ElementCountPopped;

    public void Update()
    {
        if (Input.GetMouseButton(0))
            SelectElements();

        if (Input.GetMouseButtonUp(0))
            DeselectElements();
    }

    private void DeselectElements()
    {
        if (_selectedElements.Count > 1)
            ElementCountPopped?.Invoke(_selectedElements.Count);

        foreach (Element element in _selectedElements)
        {
            element.Animator.Shake(element, false);

            if (_selectedElements.Count > 1)
                Destroy(element.gameObject);
        }

        _connectionLine.ClearLine();

        ElementsPopped?.Invoke();

        _selectedElements.Clear();
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
            AddSelected(element);

            _currentSelectedElement = _selectedElements[0];

            _connectionLine.DrawLine(0, _currentSelectedElement.transform.position);
        }
    }

    private void SelectNearestElement(Element element)
    {
        if (_selectedElements.Contains(element) == false)
            SelectTo(element);
        else if (_selectedElements.Count > 1)
            DeselectTo(element);
    }

    private void SelectTo(Element element)
    {
        if (element.GetType() == _selectedElements[0].GetType())
        {
            if (Vector3.Distance(_currentSelectedElement.transform.position, element.transform.position) < Distance)
            {
                AddSelected(element);

                _currentSelectedElement = element;

                _connectionLine.DrawLine(_selectedElements.IndexOf(_currentSelectedElement), _currentSelectedElement.transform.position);
            }
        }
    }

    private void DeselectTo(Element element)
    {
        Element requiredElement = null;

        foreach (Element selectedElement in _selectedElements)
        {
            if (element == selectedElement)
            {
                requiredElement = selectedElement;

                break;
            }
        }

        if (requiredElement != null)
        {
            for (int i = _selectedElements.Count - 1; i > _selectedElements.IndexOf(requiredElement); i--)
            {
                Element currentElement = _selectedElements[i];

                currentElement.Animator.Shake(currentElement, false);

                _connectionLine.ClearLinePart();

                _selectedElements.RemoveAt(i);
            }

            _currentSelectedElement = requiredElement;
        }
    }

    private void AddSelected(Element element)
    {
        element.Animator.Shake(element, true);

        _selectedElements.Add(element);
    }
}
