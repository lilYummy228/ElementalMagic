using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private float _drawDuration = 1f;

    public void DrawEnemy(Sprite sprite, string name)
    {
        _spriteRenderer.sprite = sprite;

        _spriteRenderer.transform.localScale = Vector3.zero;
        _spriteRenderer.transform.DOScale(Vector3.one, _drawDuration);

        _nameText.text = name;
    }

    public void Clear() =>
        _spriteRenderer.sprite = null;
}
