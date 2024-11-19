using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private float _drawDuration = 1f;

    private float _offset = 2.5f;
    private Transform _enemy;

    public Transform EnemyPosition => transform;

    public void DrawEnemy(Transform prefab, string name)
    {
        _enemy = Instantiate(prefab, transform.position + Vector3.down * _offset, Quaternion.identity);

        _enemy.localScale = Vector3.zero;
        _enemy.DOScale(Vector3.one, _drawDuration);

        _nameText.text = name;
    }

    public void Clear()
    {
        if (_enemy != null)
            Destroy(_enemy.gameObject);
    }
}