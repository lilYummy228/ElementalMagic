using System.Collections.Generic;
using UnityEngine;

public class ElementsPool : MonoBehaviour
{
    [SerializeField] private Element[] _elements;
    [SerializeField] private Transform _parent;

    private Queue<Element> _pool = new();

    public Element GetElement()
    {
        if (_pool.Count == 0)
        {
            int resourceIndex = Random.Range(0, _elements.Length);

            Element element = Instantiate(_elements[resourceIndex]);
            element.transform.parent = _parent;

            return element;
        }

        return _pool.Dequeue();
    }

    public void PutElement(Element element)
    {
        _pool.Enqueue(element);
        element.gameObject.SetActive(false);
    }
}