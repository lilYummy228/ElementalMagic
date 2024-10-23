using System;
using System.Collections.Generic;
using UnityEngine;

public class ElementConnector : MonoBehaviour
{
    private List<Element> _selectedElements = new();
    private Element _currentSelectedElement;
    private float _offset = 2f;

    public event Action ElementsPopped;

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
            element.Highlight(false);

            if (_selectedElements.Count > 1)
                Destroy(element.gameObject);
        }

        _selectedElements.Clear();

        ElementsPopped?.Invoke();
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
        }
    }

    private void SelectNearestElement(Element element)
    {
        if (_selectedElements.Contains(element) == false)
            SelectBefore(element);
        else if (_selectedElements.Count > 1)
            DeselectBefore(element);
    }

    private void SelectBefore(Element element)
    {
        if (element.GetType() == _selectedElements[0].GetType())
        {
            if (Vector3.Distance(_currentSelectedElement.transform.position, element.transform.position) < _offset)
            {
                AddSelected(element);

                _currentSelectedElement = element;
            }
        }
        else
        {
            foreach (Element selectedElement in _selectedElements)
                selectedElement.Highlight(false);

            _selectedElements.Clear();
        }
    }

    private void DeselectBefore(Element element)
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
                _selectedElements[i].Highlight(false);
                _selectedElements.RemoveAt(i);
            }

            _currentSelectedElement = requiredElement;
        }
    }

    private void AddSelected(Element element)
    {
        element.Highlight(true);

        _selectedElements.Add(element);
    }
}
