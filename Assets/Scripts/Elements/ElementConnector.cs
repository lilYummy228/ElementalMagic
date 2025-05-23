using Elements.Line;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Elements
{
    public class ElementConnector : MonoBehaviour
    {
        private const float Distance = 1.5f;
        private const int MinSelectionCount = 1;
        private const int MinDeselectionCount = 2;

        [SerializeField] private ElementConnectionLine _connectionLine;
        [SerializeField] private ElementAudioPlayer _audioPlayer;

        private List<Element> _selectedElements = new ();
        private Element _currentSelectedElement;

        public event Action Popped;
        public event Action<IReadOnlyList<Element>> ElementsFilled;

        private void Update()
        {
            if (Input.GetMouseButton(Convert.ToInt32(MouseButton.LeftMouse)))
                SelectElements();

            if (Input.GetMouseButtonUp(Convert.ToInt32(MouseButton.LeftMouse)))
                DeselectElements();
        }

        private void DeselectElements()
        {
            bool hasRequiredCount = _selectedElements.Count > MinDeselectionCount;

            _audioPlayer.AudioSourceSelection.Stop();

            if (hasRequiredCount)
            {
                _audioPlayer.PlayAttackSound(_selectedElements[0]);
                ElementsFilled?.Invoke(_selectedElements);
            }

            foreach (Element element in _selectedElements)
            {
                element.Animator.Shake(element, false);

                if (hasRequiredCount)
                {
                    element.ProjectileLaunch();
                    Destroy(element.gameObject);
                }
            }

            _connectionLine.ClearLine();

            Popped?.Invoke();

            _selectedElements.Clear();
        }

        private void SelectElements()
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

            if (hit && hit.collider.gameObject.TryGetComponent(out Element element))
            {
                SelectFirstElement(element);

                _audioPlayer.PlaySelectionSound(element);

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
            else if (_selectedElements.Count > MinSelectionCount)
                DeselectTo(element);
        }

        private void SelectTo(Element element)
        {
            if (element.ElementType == _selectedElements[0].ElementType)
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
}