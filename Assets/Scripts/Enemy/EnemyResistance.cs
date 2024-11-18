using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResistance : MonoBehaviour
{
    private const float Percent = 100;

    [SerializeField] private List<Element> _elements = new();

    private Dictionary<Element, float> _resistances = new();

    public event Action<IReadOnlyList<Element>, IReadOnlyList<int>> ResistanceChanged;

    public void Setup(IReadOnlyList<int> resistValues)
    {
        _resistances.Clear();

        for (int i = 0; i < _elements.Count; i++)
            _resistances.Add(_elements[i], resistValues[i]);

        ResistanceChanged?.Invoke(_elements, resistValues);
    }

    public float GetPercentValue(Element element)
    {
        for (int i = 0; i < _elements.Count; i++)
            if (element.GetType() == _elements[i].GetType())
                return (Percent - _resistances[_elements[i]]) / Percent;

        return 0;
    }
}
