using Elements;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Enemy
{
    public class EnemyResistanceDisplay : MonoBehaviour
    {
        [SerializeField] private EnemyResistance _resistance;
        [SerializeField] private List<TextMeshProUGUI> _list;

        private void OnEnable() =>
            _resistance.ResistanceChanged += Show;

        private void OnDisable() =>
            _resistance.ResistanceChanged -= Show;

        private void Show(IReadOnlyList<Element> elements, IReadOnlyList<int> values)
        {
            for (int i = 0; i < _list.Count; i++)
                _list[i].text = $"{values[i]}";
        }
    }
}